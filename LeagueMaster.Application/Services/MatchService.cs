using AutoMapper;
using LeagueMaster.Application.DTOs.Matches;
using LeagueMaster.Application.Interfaces.Repositories;
using LeagueMaster.Application.Interfaces.Services;
using LeagueMaster.Domain.Entities;

namespace LeagueMaster.Application.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _repo;
        private readonly IMapper _mapper;

        public MatchService(IMatchRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MatchDto>> GetAllAsync()
        {
            var matches = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<MatchDto>>(matches);
        }

        public async Task<MatchDto?> GetByIdAsync(int id)
        {
            var match = await _repo.GetByIdAsync(id);
            
            if (match == null) 
                return null;

            return _mapper.Map<MatchDto>(match);
        }

        public async Task<MatchDto> CreateAsync(MatchInputDto dto)
        {
            var match = _mapper.Map<Match>(dto);

            var created = await _repo.AddAsync(match);
            return _mapper.Map<MatchDto>(created);
        }

        public async Task<bool> UpdateAsync(int id, MatchInputDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            _mapper.Map(dto, existing);

            return await _repo.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<MatchDto>> GetByTeamIdAsync(int teamId)
        {
            var matches = await _repo.GetByTeamIdAsync(teamId);
            return _mapper.Map<IEnumerable<MatchDto>>(matches);
        }

        public async Task<IEnumerable<MatchDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var matches = await _repo.GetByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<MatchDto>>(matches);
        }
    }
}