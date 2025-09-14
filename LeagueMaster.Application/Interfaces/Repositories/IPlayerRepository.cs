using LeagueMaster.Domain.Entities;

namespace LeagueMaster.Application.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetAllAsync();
        Task<Player?> GetByIdAsync(int id);
        Task<Player> AddAsync(Player player);
        Task<bool> UpdateAsync(Player player);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Player>> GetByTeamIdAsync(int teamId);
    }
}