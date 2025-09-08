using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueMaster.Application.DTOs.Leagues
{
    public record LeagueDto(int Id, string Name, string Country, string Season, DateTime CreatedAt);
}
