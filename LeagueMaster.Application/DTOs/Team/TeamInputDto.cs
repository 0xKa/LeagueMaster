using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueMaster.Application.DTOs.Team
{
    public class TeamInputDto
    {
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public int FoundedYear { get; set; }
        public string? Stadium { get; set; }

        public int LeagueId { get; set; }
    }
}
