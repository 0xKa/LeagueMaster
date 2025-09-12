using LeagueMaster.Application.DTOs.Leagues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueMaster.Application.Interfaces.Services
{
    public interface ILeagueService
    {
        Task<IEnumerable<LeagueDto>> GetAllAsync();
        Task<LeagueDto?> GetByIdAsync(int id);
        Task<LeagueDto> CreateAsync(LeagueInputDto dto);
        Task<bool> UpdateAsync(int id, LeagueInputDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
