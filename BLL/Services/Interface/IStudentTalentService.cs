using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface IStudentTalentService
    {
        Task<IEnumerable<StudentTalentResponseDto>> GetAllAsync();
        Task<StudentTalentResponseDto> GetByIdAsync(Guid id);
        Task<StudentTalentResponseDto> CreateAsync(CreateStudentTalentRequestDto request);
        Task<StudentTalentResponseDto> UpdateAsync(UpdateStudentTalentRequestDto request);
        Task<bool> DeleteAsync(DeleteStudentTalentRequestDto request);
    }

}
