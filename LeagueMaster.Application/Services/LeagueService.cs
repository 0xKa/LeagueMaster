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
            return leagues.Select(l => new LeagueDto(l.Id, l.Name, l.Country, l.Season, l.CreatedAt));
        }

        public async Task<LeagueDto?> GetByIdAsync(int id)
        {
            var l = await _repo.GetByIdAsync(id);
            if (l == null) return null;
            return new LeagueDto(l.Id, l.Name, l.Country, l.Season, l.CreatedAt);
        }

        public async Task<LeagueDto> CreateAsync(CreateLeagueDto dto)
        {
            var l = new League
            {
                Name = dto.Name,
                Country = dto.Country,
                Season = dto.Season,
                CreatedAt = DateTime.Now
            };

            var created = await _repo.AddAsync(l);
            return new LeagueDto(created.Id, created.Name, created.Country, created.Season, created.CreatedAt);
        }

        public async Task<bool> UpdateAsync(int id, UpdateLeagueDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Name = dto.Name;
            existing.Country = dto.Country;
            existing.Season = dto.Season;

            return await _repo.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // Trust repo to report if anything was deleted
            return await _repo.DeleteAsync(id);
        }
    }
}
