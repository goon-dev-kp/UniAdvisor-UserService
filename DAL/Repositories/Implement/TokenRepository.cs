using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Models;
using DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implement
{
    public class TokenRepository : GenericRepository<UserToken>, ITokenRepository
    {
        private readonly UserServiceDbContext _context;
        public TokenRepository(UserServiceDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<UserToken> GetRefreshTokenByUserID(Guid userId)
        {
            // lấy token đúng id và chưa bị thu hồi
            return await _context.UserTokens
                .Where(rt => rt.RefreshTokenId == userId && !rt.IsRevoked)
                .FirstOrDefaultAsync();
        }
    }
}
