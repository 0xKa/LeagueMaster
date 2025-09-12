using LeagueMaster.Application.DTOs.Team;
using LeagueMaster.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueMaster.Application.Services
{
    public class TeamService : ITeamService
    {
        public Task<TeamDto> CreateAsync(TeamInputDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TeamDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TeamDto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, TeamInputDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
