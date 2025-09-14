using LeagueMaster.Application.DTOs.User;
using LeagueMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueMaster.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserInputDto userDto);
        Task<TokenResponseDto?> LoginAsync(string username, string password);
        Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request);

    }
}
