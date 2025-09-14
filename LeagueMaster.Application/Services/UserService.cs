using AutoMapper;
using LeagueMaster.Application.DTOs.User;
using LeagueMaster.Application.Interfaces.Repositories;
using LeagueMaster.Application.Interfaces.Services;
using LeagueMaster.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace LeagueMaster.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            
            if (user == null) 
                return null;

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> GetByUsernameAsync(string username)
        {
            var user = await _repo.GetByUsernameAsync(username);
            
            if (user == null) 
                return null;

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> GetByEmailAsync(string email)
        {
            var user = await _repo.GetByEmailAsync(email);
            
            if (user == null) 
                return null;

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateAsync(UserInputDto dto)
        {
            var user = _mapper.Map<User>(dto);
            
            // Hash the password
            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, dto.Password);

            var created = await _repo.AddAsync(user);
            return _mapper.Map<UserDto>(created);
        }

        public async Task<bool> UpdateAsync(int id, UserInputDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            // Map the updated fields
            _mapper.Map(dto, existing);

            var passwordHasher = new PasswordHasher<User>();
            existing.PasswordHash = passwordHasher.HashPassword(existing, dto.Password);

            existing.UpdatedAt = DateTime.Now;
            return await _repo.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(string username)
        {
            return await _repo.ExistsAsync(username);
        }
    }
}