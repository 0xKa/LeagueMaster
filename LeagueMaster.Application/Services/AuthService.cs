using AutoMapper;
using LeagueMaster.Application.DTOs.User;
using LeagueMaster.Application.Interfaces.Repositories;
using LeagueMaster.Application.Interfaces.Services;
using LeagueMaster.Domain.Entities;
using LeagueMaster.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LeagueMaster.Application.Services
{
    public class AuthService(IUserRepository userRepository, IConfiguration configuration) : IAuthService
    {
        public async Task<User?> RegisterAsync(UserInputDto userDto)
        {
            if (await userRepository.ExistsAsync(userDto.Username))
            {
                return null; // User already exists
            }

            var user = new User();
            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, userDto.Password);

            user.Username = userDto.Username;
            user.Email = userDto.Email;
            user.PasswordHash = hashedPassword;
            user.Role = UserRole.User; 

            await userRepository.AddAsync(user);
            return user;
        }

        public async Task<TokenResponseDto?> LoginAsync(UserInputDto userDto)
        {
            var user = await userRepository.GetByUsernameAsync(userDto.Username);
            if (user is null)
            {
                return null; // User not found
            }

            var result = new PasswordHasher<User>()
                .VerifyHashedPassword(user, user.PasswordHash, userDto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return null; // Invalid password
            }

            return await CreateTokenResponseAsync(user);
        }

        public async Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request)
        {
            var user = await ValidateRefreshTokenAsync(request.UserId, request.RefreshToken);

            if (user is null)
                return null;

            return await CreateTokenResponseAsync(user);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims =
            [
                new (ClaimTypes.Name, user.Username),
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Role, user.Role.ToString()),
                new (ClaimTypes.Email, user.Email)
            ];


            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(configuration.GetValue<int>("AppSettings:TokenExpirationMinutes")),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private async Task<TokenResponseDto> CreateTokenResponseAsync(User user)
        {
            var accessToken = CreateToken(user);
            var refreshToken = await GenerateAndSaveRefreshToken(user);
            
            return new TokenResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddMinutes(configuration.GetValue<int>("AppSettings:TokenExpirationMinutes")),
                Username = user.Username
            };
        }

        private async Task<string> GenerateAndSaveRefreshToken(User user)
        {
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(configuration.GetValue<int>("AppSettings:RefreshTokenExpirationDays"));
            
            await userRepository.UpdateAsync(user);
            return refreshToken;
        }

        private async Task<User?> ValidateRefreshTokenAsync(int userId, string refreshToken)
        {
            var user = await userRepository.GetByIdAsync(userId);

            if (user is null
                || user.RefreshToken != refreshToken
                || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return null; // Invalid refresh token
            }

            return user;
        }
    }
}
