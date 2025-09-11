using LeagueMaster.Application.DTOs.Leagues;
using LeagueMaster.Application.Interfaces;
using LeagueMaster.Domain.Entities;

namespace LeagueMaster.Application.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository _repo;

        public LeagueService(ILeagueRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<LeagueDto>> GetAllAsync()
        {
            var leagues = await _repo.GetAllAsync();
            return leagues.Select(l => new LeagueDto
            {
                Id = l.Id,
                Name = l.Name,
                Country = l.Country,
                Season = l.Season,
                StartDate = l.StartDate,
                EndDate = l.EndDate
            });
        }

        public async Task<LeagueDto?> GetByIdAsync(int id)
        {
            var l = await _repo.GetByIdAsync(id);
            if (l == null) return null;
            return new LeagueDto
            {
                Id = l.Id,
                Name = l.Name,
                Country = l.Country,
                Season = l.Season,
                StartDate = l.StartDate,
                EndDate = l.EndDate
            };
        }

        public async Task<LeagueDto> CreateAsync(LeagueInputDto dto)
        {
            var league = new League
            {
                Name = dto.Name,
                Country = dto.Country,
                Season = dto.Season,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                //CreatedAt = DateTime.Now, 
                //UpdatedAt = DateTime.Now // DbContext should handle audit fields

            };

            var created = await _repo.AddAsync(league);
            return new LeagueDto
            {
                Id = league.Id,
                Name = league.Name,
                Country = league.Country,
                Season = league.Season,
                StartDate = league.StartDate,
                EndDate = league.EndDate
            };
        }

        public async Task<bool> UpdateAsync(int id, LeagueInputDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Name = dto.Name;
            existing.Country = dto.Country;
            existing.Season = dto.Season;
            existing.StartDate = dto.StartDate;
            existing.EndDate = dto.EndDate;

            //existing.UpdatedAt = DateTime.Now; // db context should handle this

            return await _repo.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // Trust repo to report if anything was deleted
            return await _repo.DeleteAsync(id);
        }
    }
}
