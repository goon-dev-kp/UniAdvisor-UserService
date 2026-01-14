using BLL.Services.Interface;
using Common.DTO;
using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Implement
{
    public class StudentInterestService : IStudentInterestService
    {
        private readonly UserServiceDbContext _context;

        public StudentInterestService(UserServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentInterestResponseDto>> GetAllAsync()
        {
            return await _context.StudentInterests
                .Select(si => new StudentInterestResponseDto
                {
                    StudentInterestId = si.StudentInterestId,
                    StudentProfileId = si.StudentProfileId,
                    InterestId = si.InterestId
                })
                .ToListAsync();
        }

        public async Task<StudentInterestResponseDto> GetByIdAsync(Guid id)
        {
            var entity = await _context.StudentInterests
                .FirstOrDefaultAsync(si => si.StudentInterestId == id);

            if (entity == null)
                throw new KeyNotFoundException("StudentInterest not found");

            return new StudentInterestResponseDto
            {
                StudentInterestId = entity.StudentInterestId,
                StudentProfileId = entity.StudentProfileId,
                InterestId = entity.InterestId
            };
        }

        public async Task<StudentInterestResponseDto> CreateAsync(CreateStudentInterestRequestDto request)
        {
            var entity = new StudentInterest
            {
                StudentInterestId = Guid.NewGuid(),
                StudentProfileId = request.StudentProfileId,
                InterestId = request.InterestId
            };

            _context.StudentInterests.Add(entity);
            await _context.SaveChangesAsync();

            return new StudentInterestResponseDto
            {
                StudentInterestId = entity.StudentInterestId,
                StudentProfileId = entity.StudentProfileId,
                InterestId = entity.InterestId
            };
        }

        public async Task<StudentInterestResponseDto> UpdateAsync(UpdateStudentInterestRequestDto request)
        {
            var entity = await _context.StudentInterests
                .FirstOrDefaultAsync(si => si.StudentInterestId == request.StudentInterestId);

            if (entity == null)
                throw new KeyNotFoundException("StudentInterest not found");

            entity.StudentProfileId = request.StudentProfileId;
            entity.InterestId = request.InterestId;

            await _context.SaveChangesAsync();

            return new StudentInterestResponseDto
            {
                StudentInterestId = entity.StudentInterestId,
                StudentProfileId = entity.StudentProfileId,
                InterestId = entity.InterestId
            };
        }

        public async Task<bool> DeleteAsync(DeleteStudentInterestRequestDto request)
        {
            var entity = await _context.StudentInterests
                .FirstOrDefaultAsync(si => si.StudentInterestId == request.StudentInterestId);

            if (entity == null)
                return false;

            _context.StudentInterests.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
