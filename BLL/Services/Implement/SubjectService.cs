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
    public class SubjectService : ISubjectService
    {
        private readonly UserServiceDbContext _context;

        public SubjectService(UserServiceDbContext context)
        {
            _context = context;
        }

        public async Task<SubjectResponseDto> CreateAsync(CreateSubjectRequestDto request)
        {
            var subject = new Subject
            {
                SubjectId = Guid.NewGuid(),
                Name = request.Name
            };

            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            return new SubjectResponseDto
            {
                SubjectId = subject.SubjectId,
                Name = subject.Name
            };
        }

        public async Task<SubjectResponseDto> UpdateAsync(UpdateSubjectRequestDto request)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.SubjectId == request.SubjectId);
            if (subject == null)
                throw new KeyNotFoundException("Subject not found");

            subject.Name = request.Name;
            await _context.SaveChangesAsync();

            return new SubjectResponseDto
            {
                SubjectId = subject.SubjectId,
                Name = subject.Name
            };
        }

        public async Task<IEnumerable<SubjectResponseDto>> GetAllAsync()
        {
            return await _context.Subjects
                .Select(s => new SubjectResponseDto
                {
                    SubjectId = s.SubjectId,
                    Name = s.Name
                })
                .ToListAsync();
        }

        public async Task<SubjectResponseDto> GetByIdAsync(Guid subjectId)
        {
            var subject = await _context.Subjects
                .Where(s => s.SubjectId == subjectId)
                .Select(s => new SubjectResponseDto
                {
                    SubjectId = s.SubjectId,
                    Name = s.Name
                })
                .FirstOrDefaultAsync();

            if (subject == null)
                throw new KeyNotFoundException("Subject not found");

            return subject;
        }
        public async Task<bool> DeleteAsync(DeleteSubjectRequestDto request)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.SubjectId == request.SubjectId);
            if (subject == null)
                return false;

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}