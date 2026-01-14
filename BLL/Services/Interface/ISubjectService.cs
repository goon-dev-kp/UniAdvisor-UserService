using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface ISubjectService
    {
        Task<SubjectResponseDto> CreateAsync(CreateSubjectRequestDto request);
        Task<SubjectResponseDto> UpdateAsync(UpdateSubjectRequestDto request);
        Task<IEnumerable<SubjectResponseDto>> GetAllAsync();
        Task<SubjectResponseDto> GetByIdAsync(Guid subjectId);
        Task<bool> DeleteAsync(DeleteSubjectRequestDto request);
    }
}
