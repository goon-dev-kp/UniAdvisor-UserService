using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface IInterestService
    {
        Task<ResponseDTO> CreateAsync(CreateInterestRequestDto request);
        Task<InterestResponseDto> UpdateAsync(UpdateInterestRequestDto request);
        Task<bool> DeleteAsync(DeleteInterestRequestDto request);
        Task<ResponseDTO> GetAllAsync();
        Task<InterestResponseDto> GetByIdAsync(Guid interestId);
    }
}