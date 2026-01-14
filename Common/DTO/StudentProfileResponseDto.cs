using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class StudentProfileResponseDto
    {
        public Guid StudentProfileId { get; set; }
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public int? Age { get; set; }
        public string AiTag { get; set; }
    }

    public class CreateStudentProfileRequestDto
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public int? Age { get; set; }
        public string AiTag { get; set; }
    }

    public class UpdateStudentProfileRequestDto
    {
        public Guid StudentProfileId { get; set; }
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public int? Age { get; set; }
        public string AiTag { get; set; }
    }

    public class DeleteStudentProfileRequestDto
    {
        public Guid StudentProfileId { get; set; }
    }

}
