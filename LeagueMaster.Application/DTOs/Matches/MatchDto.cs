namespace LeagueMaster.Application.DTOs.Matches
{
    public class MatchDto
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Stadium { get; set; } = string.Empty;
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public int HomeTeamId { get; set; }
        public string HomeTeamName { get; set; } = null!;
        public int AwayTeamId { get; set; }
        public string AwayTeamName { get; set; } = null!;
    }
}