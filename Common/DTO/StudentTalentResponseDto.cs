using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class StudentTalentResponseDto
    {
        public Guid StudentTalentId { get; set; }
        public Guid StudentProfileId { get; set; }
        public Guid TalentId { get; set; }
    }

    public class CreateStudentTalentRequestDto
    {
        public Guid StudentProfileId { get; set; }
        public Guid TalentId { get; set; }
    }

    public class UpdateStudentTalentRequestDto
    {
        public Guid StudentTalentId { get; set; }
        public Guid StudentProfileId { get; set; }
        public Guid TalentId { get; set; }
    }

    public class DeleteStudentTalentRequestDto
    {
        public Guid StudentTalentId { get; set; }
    }

}
