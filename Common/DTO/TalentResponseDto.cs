using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class TalentResponseDto
    {
        public Guid TalentId { get; set; }
        public string Name { get; set; }
    }
    public class CreateTalentRequestDto
    {
        public string Name { get; set; }
    }
    public class UpdateTalentRequestDto
    {
        public Guid TalentId { get; set; }
        public string Name { get; set; }
    }
    public class DeleteTalentRequestDto
    {
        public Guid TalentId { get; set; }
    }
}
