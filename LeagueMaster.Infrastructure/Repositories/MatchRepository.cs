using LeagueMaster.Application.Interfaces.Repositories;
using LeagueMaster.Domain.Entities;
using LeagueMaster.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LeagueMaster.Infrastructure.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly LeagueMasterDbContext _context;

        public MatchRepository(LeagueMasterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Match>> GetAllAsync()
        {
            return await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .AsNoTracking()
                .OrderBy(m => m.MatchDate)
                .ToListAsync();
        }

        public async Task<Match?> GetByIdAsync(int id)
        {
            return await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Match> AddAsync(Match match)
        {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            return match;
        }

        public async Task<bool> UpdateAsync(Match match)
        {
            _context.Matches.Update(match);
            var affected = await _context.SaveChangesAsync();
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var affected = await _context.Matches.Where(m => m.Id == id).ExecuteDeleteAsync();
            return affected > 0;
        }

        public async Task<IEnumerable<Match>> GetByTeamIdAsync(int teamId)
        {
            return await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Where(m => m.HomeTeamId == teamId || m.AwayTeamId == teamId)
                .AsNoTracking()
                .OrderBy(m => m.MatchDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Match>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Where(m => m.MatchDate >= startDate && m.MatchDate <= endDate)
                .AsNoTracking()
                .OrderBy(m => m.MatchDate)
                .ToListAsync();
        }
    }
}