using LeagueMaster.Application.DTOs.Matches;

namespace LeagueMaster.Application.Interfaces.Services
{
    public interface IMatchService
    {
        Task<IEnumerable<MatchDto>> GetAllAsync();
        Task<MatchDto?> GetByIdAsync(int id);
        Task<MatchDto> CreateAsync(MatchInputDto dto);
        Task<bool> UpdateAsync(int id, MatchInputDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<MatchDto>> GetByTeamIdAsync(int teamId);
        Task<IEnumerable<MatchDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}