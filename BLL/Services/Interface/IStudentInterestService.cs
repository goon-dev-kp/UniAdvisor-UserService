using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface IStudentInterestService
    {
        Task<IEnumerable<StudentInterestResponseDto>> GetAllAsync();
        Task<StudentInterestResponseDto> GetByIdAsync(Guid id);
        Task<StudentInterestResponseDto> CreateAsync(CreateStudentInterestRequestDto request);
        Task<StudentInterestResponseDto> UpdateAsync(UpdateStudentInterestRequestDto request);
        Task<bool> DeleteAsync(DeleteStudentInterestRequestDto request);
    }
}
