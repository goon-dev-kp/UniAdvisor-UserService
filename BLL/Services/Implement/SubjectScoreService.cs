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
    public class SubjectScoreService : ISubjectScoreService
    {
        private readonly UserServiceDbContext _context;

        public SubjectScoreService(UserServiceDbContext context)
        {
            _context = context;
        }

        public async Task<SubjectScoreResponseDto> CreateAsync(CreateSubjectScoreRequestDto request)
        {
            var subjectScore = new SubjectScore
            {
                SubjectScoreId = Guid.NewGuid(),
                StudentProfileId = request.StudentProfileId,
                SubjectId = request.SubjectId,
                Score = request.Score
            };

            _context.SubjectScores.Add(subjectScore);
            await _context.SaveChangesAsync();

            return new SubjectScoreResponseDto
            {
                SubjectScoreId = subjectScore.SubjectScoreId,
                StudentProfileId = subjectScore.StudentProfileId,
                SubjectId = subjectScore.SubjectId,
                Score = subjectScore.Score
            };
        }

        public async Task<SubjectScoreResponseDto> UpdateAsync(UpdateSubjectScoreRequestDto request)
        {
            var subjectScore = await _context.SubjectScores.FirstOrDefaultAsync(s => s.SubjectScoreId == request.SubjectScoreId);
            if (subjectScore == null)
                throw new KeyNotFoundException("SubjectScore not found");

            subjectScore.Score = request.Score;
            await _context.SaveChangesAsync();

            return new SubjectScoreResponseDto
            {
                SubjectScoreId = subjectScore.SubjectScoreId,
                StudentProfileId = subjectScore.StudentProfileId,
                SubjectId = subjectScore.SubjectId,
                Score = subjectScore.Score
            };
        }

        public async Task<bool> DeleteAsync(DeleteSubjectScoreRequestDto request)
        {
            var subjectScore = await _context.SubjectScores.FirstOrDefaultAsync(s => s.SubjectScoreId == request.SubjectScoreId);
            if (subjectScore == null)
                return false;

            _context.SubjectScores.Remove(subjectScore);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SubjectScoreResponseDto>> GetAllAsync()
        {
            return await _context.SubjectScores
                .Select(s => new SubjectScoreResponseDto
                {
                    SubjectScoreId = s.SubjectScoreId,
                    StudentProfileId = s.StudentProfileId,
                    SubjectId = s.SubjectId,
                    Score = s.Score
                })
                .ToListAsync();
        }

        public async Task<SubjectScoreResponseDto> GetByIdAsync(Guid subjectScoreId)
        {
            var subjectScore = await _context.SubjectScores
                .Where(s => s.SubjectScoreId == subjectScoreId)
                .Select(s => new SubjectScoreResponseDto
                {
                    SubjectScoreId = s.SubjectScoreId,
                    StudentProfileId = s.StudentProfileId,
                    SubjectId = s.SubjectId,
                    Score = s.Score
                })
                .FirstOrDefaultAsync();

            if (subjectScore == null)
                throw new KeyNotFoundException("SubjectScore not found");

            return subjectScore;
        }
    }
}