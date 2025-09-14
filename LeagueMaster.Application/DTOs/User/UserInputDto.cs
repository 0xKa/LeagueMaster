
using LeagueMaster.Domain.Enums;

namespace LeagueMaster.Application.DTOs.User
{
    public class UserInputDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public UserRole Role { get; set; } 


    }
}
