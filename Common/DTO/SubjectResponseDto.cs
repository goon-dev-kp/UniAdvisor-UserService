using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class SubjectResponseDto
    {
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
    }

    public class CreateSubjectRequestDto
    {
        public string Name { get; set; }
    }

    public class UpdateSubjectRequestDto
    {
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
    }
    public class DeleteSubjectRequestDto
    {
        public Guid SubjectId { get; set; }
    }
}