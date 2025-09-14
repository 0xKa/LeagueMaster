using LeagueMaster.Domain.Entities;

namespace LeagueMaster.Application.Interfaces.Repositories
{
    public interface IMatchRepository
    {
        Task<IEnumerable<Match>> GetAllAsync();
        Task<Match?> GetByIdAsync(int id);
        Task<Match> AddAsync(Match match);
        Task<bool> UpdateAsync(Match match);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Match>> GetByTeamIdAsync(int teamId);
        Task<IEnumerable<Match>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}