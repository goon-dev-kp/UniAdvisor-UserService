using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface IStudentProfileService
    {
        Task<IEnumerable<StudentProfileResponseDto>> GetAllAsync();
        Task<StudentProfileResponseDto> GetByIdAsync(Guid id);
        Task<StudentProfileResponseDto> CreateAsync(CreateStudentProfileRequestDto request);
        Task<StudentProfileResponseDto> UpdateAsync(UpdateStudentProfileRequestDto request);
        Task<bool> DeleteAsync(DeleteStudentProfileRequestDto request);
    }

}
