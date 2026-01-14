using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class StudentInterestResponseDto
    {
        public Guid StudentInterestId { get; set; }
        public Guid StudentProfileId { get; set; }
        public Guid InterestId { get; set; }
    }

    public class CreateStudentInterestRequestDto
    {
        public Guid StudentProfileId { get; set; }
        public Guid InterestId { get; set; }
    }

    public class UpdateStudentInterestRequestDto
    {
        public Guid StudentInterestId { get; set; }
        public Guid StudentProfileId { get; set; }
        public Guid InterestId { get; set; }
    }

    public class DeleteStudentInterestRequestDto
    {
        public Guid StudentInterestId { get; set; }
    }
}
