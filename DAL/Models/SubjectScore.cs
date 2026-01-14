using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SubjectScore
    {
        public Guid SubjectScoreId { get; set; } = Guid.NewGuid();

        public Guid StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        [Range(0, 10)]
        public double Score { get; set; }
    }
}
