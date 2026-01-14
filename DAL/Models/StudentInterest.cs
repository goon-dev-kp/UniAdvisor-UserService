using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class StudentInterest
    {
        public Guid StudentInterestId { get; set; }
        public Guid StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; }

        public Guid InterestId { get; set; }
        public Interest Interest { get; set; }
    }
}
