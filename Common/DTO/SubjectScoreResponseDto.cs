using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class SubjectScoreResponseDto
    {
        public Guid SubjectScoreId { get; set; }
        public Guid StudentProfileId { get; set; }
        public Guid SubjectId { get; set; }
        public double Score { get; set; }
    }

    public class CreateSubjectScoreRequestDto
    {
        public Guid StudentProfileId { get; set; }
        public Guid SubjectId { get; set; }
        public double Score { get; set; }
    }

    public class UpdateSubjectScoreRequestDto
    {
        public Guid SubjectScoreId { get; set; }
        public double Score { get; set; }
    }

    public class DeleteSubjectScoreRequestDto
    {
        public Guid SubjectScoreId { get; set; }
    }
}