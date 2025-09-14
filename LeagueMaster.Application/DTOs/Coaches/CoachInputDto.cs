using System.ComponentModel.DataAnnotations;

namespace LeagueMaster.Application.DTOs.Coaches
{
    public class CoachInputDto
    {
        [Required]
        public string FirstName { get; set; } = null!;
        
        public string? LastName { get; set; }
        
        [Required]
        public string Nationality { get; set; } = null!;
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        [Range(0, 50)]
        public int ExperienceYears { get; set; }
        
        [Required]
        public int TeamId { get; set; }
    }
}