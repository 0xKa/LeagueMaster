using LeagueMaster.Application.Interfaces.Repositories;
using LeagueMaster.Domain.Entities;
using LeagueMaster.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LeagueMaster.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly LeagueMasterDbContext _context;

        public PlayerRepository(LeagueMasterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _context.Players
                .Include(p => p.Team)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Player?> GetByIdAsync(int id)
        {
            return await _context.Players
                .Include(p => p.Team)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Player> AddAsync(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<bool> UpdateAsync(Player player)
        {
            _context.Players.Update(player);
            var affected = await _context.SaveChangesAsync();
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var affected = await _context.Players.Where(p => p.Id == id).ExecuteDeleteAsync();
            return affected > 0;
        }

        public async Task<IEnumerable<Player>> GetByTeamIdAsync(int teamId)
        {
            return await _context.Players
                .Include(p => p.Team)
                .Where(p => p.TeamId == teamId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}