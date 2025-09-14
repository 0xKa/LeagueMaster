using AutoMapper;
using LeagueMaster.Application.DTOs.User;
using LeagueMaster.Application.Interfaces.Repositories;
using LeagueMaster.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;

namespace LeagueMaster.Application.Services
{
    public class AuthService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration) : IAuthService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IConfiguration _configuration = configuration;

        public Task<UserInputDto?> RegisterAsync(UserInputDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<TokenResponseDto?> LoginAsync(UserInputDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request)
        {
            throw new NotImplementedException();
        }

    }
}
