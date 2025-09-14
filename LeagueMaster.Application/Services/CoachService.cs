using AutoMapper;
using LeagueMaster.Application.DTOs.Coaches;
using LeagueMaster.Application.Interfaces.Repositories;
using LeagueMaster.Application.Interfaces.Services;
using LeagueMaster.Domain.Entities;

namespace LeagueMaster.Application.Services
{
    public class CoachService : ICoachService
    {
        private readonly ICoachRepository _repo;
        private readonly IMapper _mapper;

        public CoachService(ICoachRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CoachDto>> GetAllAsync()
        {
            var coaches = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<CoachDto>>(coaches);
        }

        public async Task<CoachDto?> GetByIdAsync(int id)
        {
            var coach = await _repo.GetByIdAsync(id);
            
            if (coach == null) 
                return null;

            return _mapper.Map<CoachDto>(coach);
        }

        public async Task<CoachDto> CreateAsync(CoachInputDto dto)
        {
            var coach = _mapper.Map<Coach>(dto);

            var created = await _repo.AddAsync(coach);
            return _mapper.Map<CoachDto>(created);
        }

        public async Task<bool> UpdateAsync(int id, CoachInputDto dto)
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

        public async Task<CoachDto?> GetByTeamIdAsync(int teamId)
        {
            var coach = await _repo.GetByTeamIdAsync(teamId);
            
            if (coach == null) 
                return null;

            return _mapper.Map<CoachDto>(coach);
        }
    }
}