using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class InterestResponseDto
    {
        public Guid InterestId { get; set; }
        public string Name { get; set; }
    }

    public class CreateInterestRequestDto
    {
        public string Name { get; set; }
    }

    public class UpdateInterestRequestDto
    {
        public Guid InterestId { get; set; }
        public string Name { get; set; }
    }

    public class DeleteInterestRequestDto
    {
        public Guid InterestId { get; set; }
    }
}