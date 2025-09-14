using LeagueMaster.Domain.Entities;

namespace LeagueMaster.Application.Interfaces.Repositories
{
    public interface ICoachRepository
    {
        Task<IEnumerable<Coach>> GetAllAsync();
        Task<Coach?> GetByIdAsync(int id);
        Task<Coach> AddAsync(Coach coach);
        Task<bool> UpdateAsync(Coach coach);
        Task<bool> DeleteAsync(int id);
        Task<Coach?> GetByTeamIdAsync(int teamId);
    }
}