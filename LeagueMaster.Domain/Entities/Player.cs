using LeagueMaster.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueMaster.Domain.Entities
{
    public class Player : BaseDomainObject
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; } = null!;
        public PlayerPosition Position { get; set; }
        public int ShirtNumber { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;

    }
}
