using LeagueMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueMaster.Application.Interfaces
{
    public interface ILeagueRepository
    {
        Task<IEnumerable<League>> GetAllAsync();
        Task<League?> GetByIdAsync(int id);
        Task<League> AddAsync(League league);
        Task<bool> UpdateAsync(League league);
        Task<bool> DeleteAsync(int id);
    }
}
