using LeagueMaster.Application.DTOs.Coaches;

namespace LeagueMaster.Application.Interfaces.Services
{
    public interface ICoachService
    {
        Task<IEnumerable<CoachDto>> GetAllAsync();
        Task<CoachDto?> GetByIdAsync(int id);
        Task<CoachDto> CreateAsync(CoachInputDto dto);
        Task<bool> UpdateAsync(int id, CoachInputDto dto);
        Task<bool> DeleteAsync(int id);
        Task<CoachDto?> GetByTeamIdAsync(int teamId);
    }
}