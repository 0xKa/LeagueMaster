using LeagueMaster.Domain.Entities;

namespace LeagueMaster.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
        Task<User> AddAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(string username, string email);
        Task<User?> GetByRefreshTokenAsync(string refreshToken);
    }
}