using System.ComponentModel.DataAnnotations;

namespace LeagueMaster.Application.DTOs.Leagues
{
    public class CreateLeagueDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Country { get; set; } = null!;
        [Required]
        public string Season { get; set; } = null!;
    }

}
