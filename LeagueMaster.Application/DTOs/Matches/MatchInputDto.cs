using System.ComponentModel.DataAnnotations;

namespace LeagueMaster.Application.DTOs.Matches
{
    public class MatchInputDto
    {
        [Required]
        public DateTime MatchDate { get; set; }
        
        [Required]
        public string Location { get; set; } = string.Empty;
        
        [Required]
        public string Stadium { get; set; } = string.Empty;
        
        [Range(0, 50)]
        public int HomeTeamScore { get; set; }
        
        [Range(0, 50)]
        public int AwayTeamScore { get; set; }
        
        [Required]
        public int HomeTeamId { get; set; }
        
        [Required]
        public int AwayTeamId { get; set; }
    }
}