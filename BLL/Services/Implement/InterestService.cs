using BLL.Services.Interface;
using Common.DTO;
using DAL.Data;
using DAL.Models;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services.Implement
{
    public class InterestService : IInterestService
    {
        private readonly UserServiceDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public InterestService(UserServiceDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO> CreateAsync(CreateInterestRequestDto request)
        {
            var interest = new Interest
            {
                InterestId = Guid.NewGuid(),
                Name = request.Name
            };

            _context.Interests.Add(interest);
            await _context.SaveChangesAsync();

            return new ResponseDTO("Interest created successfully", 200, true);
            ;
        }

        public async Task<InterestResponseDto> UpdateAsync(UpdateInterestRequestDto request)
        {
            var interest = await _context.Interests.FirstOrDefaultAsync(i => i.InterestId == request.InterestId);
            if (interest == null)
                throw new KeyNotFoundException("Interest not found");

            interest.Name = request.Name;
            await _context.SaveChangesAsync();

            return new InterestResponseDto
            {
                InterestId = interest.InterestId,
                Name = interest.Name
            };
        }

        public async Task<bool> DeleteAsync(DeleteInterestRequestDto request)
        {
            var interest = await _context.Interests.FirstOrDefaultAsync(i => i.InterestId == request.InterestId);
            if (interest == null)
                return false;

            _context.Interests.Remove(interest);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ResponseDTO> GetAllAsync()
        {
            var interests = _unitOfWork.InterestRepo.GetAll();
            if (interests == null || !interests.Any()) 
            { 
                return new ResponseDTO("No interests found", 404, false);
            }
            var interestDtos = interests.Select(i => new InterestResponseDto
            {
                InterestId = i.InterestId,
                Name = i.Name
            }).ToList();

            return new ResponseDTO("Interests retrieved successfully", 200, true, interestDtos);
        }

        public async Task<InterestResponseDto> GetByIdAsync(Guid interestId)
        {
            var interest = await _context.Interests
                .Where(i => i.InterestId == interestId)
                .Select(i => new InterestResponseDto
                {
                    InterestId = i.InterestId,
                    Name = i.Name
                })
                .FirstOrDefaultAsync();

            if (interest == null)
                throw new KeyNotFoundException("Interest not found");

            return interest;
        }
    }
}