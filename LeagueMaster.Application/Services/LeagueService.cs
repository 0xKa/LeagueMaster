using AutoMapper;
using LeagueMaster.Application.DTOs.Leagues;
using LeagueMaster.Application.Interfaces;
using LeagueMaster.Domain.Entities;

namespace LeagueMaster.Application.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository _repo;
        private readonly IMapper _mapper;

        public LeagueService(ILeagueRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LeagueDto>> GetAllAsync()
        {
            var leagues = await _repo.GetAllAsync();
            return  _mapper.Map<IEnumerable<LeagueDto>>(leagues);
        }

        public async Task<LeagueDto?> GetByIdAsync(int id)
        {
            var league = await _repo.GetByIdAsync(id);
            
            if (league == null) 
                return null;

            return _mapper.Map<LeagueDto>(league);
        }

        public async Task<LeagueDto> CreateAsync(LeagueInputDto dto)
        {
            var league = _mapper.Map<League>(dto);

            var created = await _repo.AddAsync(league);
            return _mapper.Map<LeagueDto>(created);
        }

        public async Task<bool> UpdateAsync(int id, LeagueInputDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            _mapper.Map(dto, existing);

            return await _repo.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // Trust repo to report if anything was deleted
            return await _repo.DeleteAsync(id);
        }
    }
}
