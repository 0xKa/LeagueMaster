using LeagueMaster.Application.DTOs.Players;

namespace LeagueMaster.Application.Interfaces.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerDto>> GetAllAsync();
        Task<PlayerDto?> GetByIdAsync(int id);
        Task<PlayerDto> CreateAsync(PlayerInputDto dto);
        Task<bool> UpdateAsync(int id, PlayerInputDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<PlayerDto>> GetByTeamIdAsync(int teamId);
    }
}