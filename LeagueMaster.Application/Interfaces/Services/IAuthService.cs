using LeagueMaster.Application.DTOs.User;
using LeagueMaster.Domain.Entities;

namespace LeagueMaster.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserInputDto userDto);
        Task<TokenResponseDto?> LoginAsync(string username, string password);
        Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request);
    }
}
