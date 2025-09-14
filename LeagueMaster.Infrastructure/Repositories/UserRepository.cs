using LeagueMaster.Application.Interfaces.Repositories;
using LeagueMaster.Domain.Entities;
using LeagueMaster.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LeagueMaster.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LeagueMasterDbContext _context;

        public UserRepository(LeagueMasterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            var affected = await _context.SaveChangesAsync();
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var affected = await _context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
            return affected > 0;
        }

        public async Task<bool> ExistsAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }

        public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        }
    }
}