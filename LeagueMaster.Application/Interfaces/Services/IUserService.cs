using LeagueMaster.Application.DTOs.User;

namespace LeagueMaster.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto?> GetByUsernameAsync(string username);
        Task<UserDto?> GetByEmailAsync(string email);
        Task<UserDto> CreateAsync(UserInputDto dto);
        Task<bool> UpdateAsync(int id, UserInputDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(string username);
    }
}