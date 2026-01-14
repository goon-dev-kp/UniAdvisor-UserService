using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface ITalentService
    {
        Task<TalentResponseDto> CreateAsync(CreateTalentRequestDto request);
        Task<TalentResponseDto> UpdateAsync(UpdateTalentRequestDto request);
        Task<bool> DeleteAsync(DeleteTalentRequestDto request);
        Task<IEnumerable<TalentResponseDto>> GetAllAsync();
        Task<TalentResponseDto> GetByIdAsync(Guid talentId);
    }
}
