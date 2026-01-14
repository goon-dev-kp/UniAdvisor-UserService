using BLL.Services.Interface;
using Common.DTO;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services.Implement
{
    public class StudentProfileService : IStudentProfileService
    {
        private readonly UserServiceDbContext _context;

        public StudentProfileService(UserServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentProfileResponseDto>> GetAllAsync()
        {
            return await _context.StudentProfiles
                .Select(sp => new StudentProfileResponseDto
                {
                    StudentProfileId = sp.StudentProfileId,
                    UserId = sp.UserId,
                    FullName = sp.FullName,
                    Age = sp.Age,
                    AiTag = sp.AiTag
                })
                .ToListAsync();
        }

        public async Task<StudentProfileResponseDto> GetByIdAsync(Guid id)
        {
            var profile = await _context.StudentProfiles
                .FirstOrDefaultAsync(sp => sp.StudentProfileId == id);

            if (profile == null)
                throw new KeyNotFoundException("StudentProfile not found");

            return new StudentProfileResponseDto
            {
                StudentProfileId = profile.StudentProfileId,
                UserId = profile.UserId,
                FullName = profile.FullName,
                Age = profile.Age,
                AiTag = profile.AiTag
            };
        }

        public async Task<StudentProfileResponseDto> CreateAsync(CreateStudentProfileRequestDto request)
        {
            var profile = new StudentProfile
            {
                StudentProfileId = Guid.NewGuid(),
                UserId = request.UserId,
                FullName = request.FullName,
                Age = request.Age,
                AiTag = request.AiTag
            };

            _context.StudentProfiles.Add(profile);
            await _context.SaveChangesAsync();

            return new StudentProfileResponseDto
            {
                StudentProfileId = profile.StudentProfileId,
                UserId = profile.UserId,
                FullName = profile.FullName,
                Age = profile.Age,
                AiTag = profile.AiTag
            };
        }

        public async Task<StudentProfileResponseDto> UpdateAsync(UpdateStudentProfileRequestDto request)
        {
            var profile = await _context.StudentProfiles
                .FirstOrDefaultAsync(sp => sp.StudentProfileId == request.StudentProfileId);

            if (profile == null)
                throw new KeyNotFoundException("StudentProfile not found");

            profile.UserId = request.UserId;
            profile.FullName = request.FullName;
            profile.Age = request.Age;
            profile.AiTag = request.AiTag;

            await _context.SaveChangesAsync();

            return new StudentProfileResponseDto
            {
                StudentProfileId = profile.StudentProfileId,
                UserId = profile.UserId,
                FullName = profile.FullName,
                Age = profile.Age,
                AiTag = profile.AiTag
            };
        }

        public async Task<bool> DeleteAsync(DeleteStudentProfileRequestDto request)
        {
            var profile = await _context.StudentProfiles
                .FirstOrDefaultAsync(sp => sp.StudentProfileId == request.StudentProfileId);

            if (profile == null)
                return false;

            _context.StudentProfiles.Remove(profile);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
