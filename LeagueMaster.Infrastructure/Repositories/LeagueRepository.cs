using LeagueMaster.Application.Interfaces;
using LeagueMaster.Domain.Entities;
using LeagueMaster.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LeagueMaster.Infrastructure.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly LeagueMasterDbContext _context;

        public LeagueRepository(LeagueMasterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<League>> GetAllAsync()
        {
            return await _context.Leagues.AsNoTracking().ToListAsync();
        }

        public async Task<League?> GetByIdAsync(int id)
        {
            return await _context.Leagues.FindAsync(id);
        }

        public async Task<League> AddAsync(League league)
        {
            _context.Leagues.Add(league);
            await _context.SaveChangesAsync();
            return league;
        }

        public async Task<bool> UpdateAsync(League league)
        {
            _context.Leagues.Update(league);
            var affected = await _context.SaveChangesAsync();
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var affected = await _context.Leagues.Where(l => l.Id == id).ExecuteDeleteAsync();
            return affected > 0;
        }
    }
}
