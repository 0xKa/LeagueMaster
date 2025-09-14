using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueMaster.Domain.Entities
{
    public class Match : BaseDomainObject
    {
        public DateTime MatchDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Stadium { get; set; } = string.Empty;

        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; } 
        
        public int HomeTeamId { get; set; }
        public Team? HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public Team? AwayTeam { get; set; }

    }
}
