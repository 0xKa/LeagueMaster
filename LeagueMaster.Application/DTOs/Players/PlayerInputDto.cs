using LeagueMaster.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LeagueMaster.Application.DTOs.Players
{
    public class PlayerInputDto
    {
        [Required]
        public string FirstName { get; set; } = null!;
        
        public string? LastName { get; set; }
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        public string Nationality { get; set; } = null!;
        
        [Required]
        public PlayerPosition Position { get; set; }
        
        [Required]
        [Range(1, 99)]
        public int ShirtNumber { get; set; }
        
        [Required]
        public int TeamId { get; set; }
    }
}