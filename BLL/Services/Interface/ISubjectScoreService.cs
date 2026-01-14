using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface ISubjectScoreService
    {
        Task<SubjectScoreResponseDto> CreateAsync(CreateSubjectScoreRequestDto request);
        Task<SubjectScoreResponseDto> UpdateAsync(UpdateSubjectScoreRequestDto request);
        Task<bool> DeleteAsync(DeleteSubjectScoreRequestDto request);
        Task<IEnumerable<SubjectScoreResponseDto>> GetAllAsync();
        Task<SubjectScoreResponseDto> GetByIdAsync(Guid subjectScoreId);
    }
}