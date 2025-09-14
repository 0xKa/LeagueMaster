using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueMaster.Domain.Entities
{
    public class Coach : BaseDomainObject
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Nationality { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public int ExperienceYears { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;



    }
}
