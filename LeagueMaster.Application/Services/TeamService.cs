using AutoMapper;
using LeagueMaster.Application.DTOs.Team;
using LeagueMaster.Application.Interfaces.Repositories;
using LeagueMaster.Application.Interfaces.Services;
using LeagueMaster.Domain.Entities;

namespace LeagueMaster.Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _repo;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeamDto>> GetAllAsync()
        {
            var teams = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<TeamDto>>(teams);
        }

        public async Task<TeamDto?> GetByIdAsync(int id)
        {
            var team = await _repo.GetByIdAsync(id);
            
            if (team == null) 
                return null;

            return _mapper.Map<TeamDto>(team);
        }

        public async Task<TeamDto> CreateAsync(TeamInputDto dto)
        {
            var team = _mapper.Map<Team>(dto);

            var created = await _repo.AddAsync(team);
            return _mapper.Map<TeamDto>(created);
        }

        public async Task<bool> UpdateAsync(int id, TeamInputDto dto)
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
    }
}
