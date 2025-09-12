using LeagueMaster.Application.DTOs.Team;

namespace LeagueMaster.Application.Interfaces.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDto>> GetAllAsync();
        Task<TeamDto?> GetByIdAsync(int id);
        Task<TeamDto> CreateAsync(TeamInputDto dto);
        Task<bool> UpdateAsync(int id, TeamInputDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
