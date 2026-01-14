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
    public class StudentTalentService : IStudentTalentService
    {
        private readonly UserServiceDbContext _context;

        public StudentTalentService(UserServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentTalentResponseDto>> GetAllAsync()
        {
            return await _context.StudentTalents
                .Select(t => new StudentTalentResponseDto
                {
                    StudentTalentId = t.StudentTalentId,
                    StudentProfileId = t.StudentProfileId,
                    TalentId = t.TalentId
                }).ToListAsync();
        }

        public async Task<StudentTalentResponseDto> GetByIdAsync(Guid id)
        {
            var entity = await _context.StudentTalents
                .FirstOrDefaultAsync(t => t.StudentTalentId == id);

            if (entity == null)
                throw new KeyNotFoundException("StudentTalent not found");

            return new StudentTalentResponseDto
            {
                StudentTalentId = entity.StudentTalentId,
                StudentProfileId = entity.StudentProfileId,
                TalentId = entity.TalentId
            };
        }

        public async Task<StudentTalentResponseDto> CreateAsync(CreateStudentTalentRequestDto request)
        {
            var entity = new StudentTalent
            {
                StudentTalentId = Guid.NewGuid(),
                StudentProfileId = request.StudentProfileId,
                TalentId = request.TalentId
            };

            _context.StudentTalents.Add(entity);
            await _context.SaveChangesAsync();

            return new StudentTalentResponseDto
            {
                StudentTalentId = entity.StudentTalentId,
                StudentProfileId = entity.StudentProfileId,
                TalentId = entity.TalentId
            };
        }

        public async Task<StudentTalentResponseDto> UpdateAsync(UpdateStudentTalentRequestDto request)
        {
            var entity = await _context.StudentTalents
                .FirstOrDefaultAsync(t => t.StudentTalentId == request.StudentTalentId);

            if (entity == null)
                throw new KeyNotFoundException("StudentTalent not found");

            entity.StudentProfileId = request.StudentProfileId;
            entity.TalentId = request.TalentId;

            await _context.SaveChangesAsync();

            return new StudentTalentResponseDto
            {
                StudentTalentId = entity.StudentTalentId,
                StudentProfileId = entity.StudentProfileId,
                TalentId = entity.TalentId
            };
        }

        public async Task<bool> DeleteAsync(DeleteStudentTalentRequestDto request)
        {
            var entity = await _context.StudentTalents
                .FirstOrDefaultAsync(t => t.StudentTalentId == request.StudentTalentId);

            if (entity == null)
                return false;

            _context.StudentTalents.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
