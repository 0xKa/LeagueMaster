using LeagueMaster.Application.Interfaces.Repositories;
using LeagueMaster.Domain.Entities;
using LeagueMaster.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LeagueMaster.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly LeagueMasterDbContext _context;

        public TeamRepository(LeagueMasterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _context.Teams.AsNoTracking().ToListAsync();
        }

        public async Task<Team?> GetByIdAsync(int id)
        {
            return await _context.Teams
                .Include(t => t.League)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Team> AddAsync(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<bool> UpdateAsync(Team team)
        {
            _context.Teams.Update(team);
            var affected = await _context.SaveChangesAsync();
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var affected = await _context.Teams.Where(t => t.Id == id).ExecuteDeleteAsync();
            return affected > 0;
        }
    }
}
