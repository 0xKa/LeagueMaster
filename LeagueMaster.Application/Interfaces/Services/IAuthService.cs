using LeagueMaster.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueMaster.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<UserInputDto?> RegisterAsync(UserInputDto userDto);
        Task<TokenResponseDto?> LoginAsync(UserInputDto userDto);
        Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request);

    }
}
