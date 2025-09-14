using LeagueMaster.Domain.Enums;

namespace LeagueMaster.Domain.Entities
{
    public class User : BaseDomainObject
    {
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Email { get; set; } = null!;
        public UserRole Role { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

    }
}
