using LeagueMaster.Application.Interfaces.Repositories;
using LeagueMaster.Domain.Entities;
using LeagueMaster.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LeagueMaster.Infrastructure.Repositories
{
    public class CoachRepository : ICoachRepository
    {
        private readonly LeagueMasterDbContext _context;

        public CoachRepository(LeagueMasterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Coach>> GetAllAsync()
        {
            return await _context.Coaches
                .Include(c => c.Team)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Coach?> GetByIdAsync(int id)
        {
            return await _context.Coaches
                .Include(c => c.Team)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Coach> AddAsync(Coach coach)
        {
            _context.Coaches.Add(coach);
            await _context.SaveChangesAsync();
            return coach;
        }

        public async Task<bool> UpdateAsync(Coach coach)
        {
            _context.Coaches.Update(coach);
            var affected = await _context.SaveChangesAsync();
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var affected = await _context.Coaches.Where(c => c.Id == id).ExecuteDeleteAsync();
            return affected > 0;
        }

        public async Task<Coach?> GetByTeamIdAsync(int teamId)
        {
            return await _context.Coaches
                .Include(c => c.Team)
                .FirstOrDefaultAsync(c => c.TeamId == teamId);
        }
    }
}