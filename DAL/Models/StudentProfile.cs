using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class StudentProfile
    {
        public Guid StudentProfileId { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }
        public User User { get; set; }

        [MaxLength(50)]
        public string FullName { get; set; }

        public int? Age { get; set; }

        public string? AiTag { get; set; }



        public ICollection<SubjectScore> SubjectScores { get; set; }
        public ICollection<StudentInterest> Interests { get; set; }
        public ICollection<StudentTalent> Talents { get; set; }
    }
}
