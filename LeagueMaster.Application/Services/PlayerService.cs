using AutoMapper;
using LeagueMaster.Application.DTOs.Players;
using LeagueMaster.Application.Interfaces.Repositories;
using LeagueMaster.Application.Interfaces.Services;
using LeagueMaster.Domain.Entities;

namespace LeagueMaster.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _repo;
        private readonly IMapper _mapper;

        public PlayerService(IPlayerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayerDto>> GetAllAsync()
        {
            var players = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<PlayerDto>>(players);
        }

        public async Task<PlayerDto?> GetByIdAsync(int id)
        {
            var player = await _repo.GetByIdAsync(id);
            
            if (player == null) 
                return null;

            return _mapper.Map<PlayerDto>(player);
        }

        public async Task<PlayerDto> CreateAsync(PlayerInputDto dto)
        {
            var player = _mapper.Map<Player>(dto);

            var created = await _repo.AddAsync(player);
            return _mapper.Map<PlayerDto>(created);
        }

        public async Task<bool> UpdateAsync(int id, PlayerInputDto dto)
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

        public async Task<IEnumerable<PlayerDto>> GetByTeamIdAsync(int teamId)
        {
            var players = await _repo.GetByTeamIdAsync(teamId);
            return _mapper.Map<IEnumerable<PlayerDto>>(players);
        }
    }
}