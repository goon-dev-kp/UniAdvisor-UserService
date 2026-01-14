using BLL.Services.Interface;
using Common.DTO;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implement
{
    public class TalentService : ITalentService
    {
        private readonly UserServiceDbContext _context;

        public TalentService(UserServiceDbContext context)
        {
            _context = context;
        }

        public async Task<TalentResponseDto> CreateAsync(CreateTalentRequestDto request)
        {
            var talent = new Talent
            {
                TalentId = Guid.NewGuid(),
                Name = request.Name
            };

            _context.Talents.Add(talent);
            await _context.SaveChangesAsync();

            return new TalentResponseDto
            {
                TalentId = talent.TalentId,
                Name = talent.Name
            };
        }
        public async Task<TalentResponseDto> UpdateAsync(UpdateTalentRequestDto request)
        {
            var talent = await _context.Talents.FirstOrDefaultAsync(t => t.TalentId == request.TalentId);
            if (talent == null)
                throw new KeyNotFoundException("Talent not found");

            talent.Name = request.Name;
            await _context.SaveChangesAsync();

            return new TalentResponseDto
            {
                TalentId = talent.TalentId,
                Name = talent.Name
            };
        }
        public async Task<bool> DeleteAsync(DeleteTalentRequestDto request)
        {
            var talent = await _context.Talents.FirstOrDefaultAsync(t => t.TalentId == request.TalentId);
            if (talent == null)
                return false;

            _context.Talents.Remove(talent);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<TalentResponseDto>> GetAllAsync()
        {
            return await _context.Talents
                .Select(t => new TalentResponseDto
                {
                    TalentId = t.TalentId,
                    Name = t.Name
                })
                .ToListAsync();
        }

        public async Task<TalentResponseDto> GetByIdAsync(Guid talentId)
        {
            var talent = await _context.Talents
                .Where(t => t.TalentId == talentId)
                .Select(t => new TalentResponseDto
                {
                    TalentId = t.TalentId,
                    Name = t.Name
                })
                .FirstOrDefaultAsync();

            if (talent == null)
                throw new KeyNotFoundException("Talent not found");

            return talent;
        }

    }
}
