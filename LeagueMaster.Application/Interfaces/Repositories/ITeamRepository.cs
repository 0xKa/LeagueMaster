using LeagueMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueMaster.Application.Interfaces.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team?> GetByIdAsync(int id);
        Task<Team> AddAsync(Team team);
        Task<bool> UpdateAsync(Team team);
        Task<bool> DeleteAsync(int id);
    }
}
