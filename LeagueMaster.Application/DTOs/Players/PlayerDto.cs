using LeagueMaster.Domain.Enums;

namespace LeagueMaster.Application.DTOs.Players
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; } = null!;
        public PlayerPosition Position { get; set; }
        public int ShirtNumber { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; } = null!;
    }
}