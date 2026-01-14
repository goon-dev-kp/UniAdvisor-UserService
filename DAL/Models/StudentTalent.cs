using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class StudentTalent
    {
        public Guid StudentTalentId { get; set; } 
        public Guid StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; }

        public Guid TalentId { get; set; }
        public Talent Talent { get; set; }
    }
}
