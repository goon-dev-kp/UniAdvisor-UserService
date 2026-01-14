using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Interface;
using BLL.Utilities;
using Common.Constants;
using Common.DTO;
using Common.Enums;
using DAL.Models;
using DAL.UnitOfWork;


namespace BLL.Services.Implement
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserUtility _userUtility;
        public AuthService(IUnitOfWork unitOfWork, UserUtility userUtility)
        {
            _unitOfWork = unitOfWork;
            _userUtility = userUtility;
        }
        public async Task<ResponseDTO> LoginAsync(LoginDTO loginDTO)
        {
            //kiểm tra email
            var user = await _unitOfWork.UserRepo.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                return new ResponseDTO("User not found", 400, false);
            }

            // kiểm tra mật khẩu
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                return new ResponseDTO("Password is not correct", 400, false);
            }


            //kiểm tra token
            var exitsRefreshToken = await _unitOfWork.TokenRepo.GetRefreshTokenByUserID(user.UserId);
            if (exitsRefreshToken != null)
            {
                exitsRefreshToken.IsRevoked = true;
                await _unitOfWork.TokenRepo.UpdateAsync(exitsRefreshToken);
            }

            //khởi tạo claim
            var claims = new List<Claim>
            {
                new Claim(JwtConstant.KeyClaim.userId, user.UserId.ToString()),
                new Claim(JwtConstant.KeyClaim.Role, user.Role.ToString())
            };

            //tạo refesh token
            var refreshTokenKey = JwtProvider.GenerateRefreshToken(claims);
            var accessTokenKey = JwtProvider.GenerateAccessToken(claims);

            var refreshToken = new UserToken
            {
                RefreshTokenId = Guid.NewGuid(),
                RefreshTokenKey = refreshTokenKey,
                UserId = user.UserId,
                IsRevoked = false,
                Type = TokenType.REFRESH_TOKEN,
                CreatedAt = DateTime.UtcNow
            };

            _unitOfWork.TokenRepo.Add(refreshToken);
            try
            {
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                return new ResponseDTO($"Error saving refresh token: {ex.Message}", 500, false);
            }


            return new ResponseDTO("Login successfullt", 200, true, new
            {
                AccessToken = accessTokenKey,
            });
        }

        public async Task<ResponseDTO> LogoutAsync()
        {
            var userId = _userUtility.GetUserIdFromToken();
            if (userId == null)
            {
                return new ResponseDTO("User not found", 400, false);
            }
            // lấy refresh token của người dùng
            var refreshToken = await _unitOfWork.TokenRepo.GetRefreshTokenByUserID(userId);
            if (refreshToken == null)
            {
                return new ResponseDTO("Refresh token not found", 404, false);
            }
            // đánh dấu token là đã thu hồi
            refreshToken.IsRevoked = true;
            try
            {
                await _unitOfWork.TokenRepo.UpdateAsync(refreshToken);
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                return new ResponseDTO($"Error revoking token: {ex.Message}", 500, false);
            }
            return new ResponseDTO("Logout successfully", 200, true);
        }

        public async Task<ResponseDTO> RegisterAsync(RegisterDTO registerDTO)
        {


            // kiểm tra email đã tồn tại
            var existingUser = await _unitOfWork.UserRepo.FindByEmailAsync(registerDTO.Email);
            if (existingUser != null)
            {
                return new ResponseDTO("Email already exists", 400, false);
            }
            // tạo người dùng mới
            var newUser = new User
            {
                UserId = Guid.NewGuid(),
                Email = registerDTO.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password),
                Role = RoleType.STUDENT, // Mặc định là sinh viên

            };

            try
            {
                await _unitOfWork.UserRepo.AddAsync(newUser);
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                return new ResponseDTO($"Error creating user: {ex.Message}", 500, false);
            }
            return new ResponseDTO("User created successfully", 201, true);
        }
    }
}
