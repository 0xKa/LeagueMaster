namespace LeagueMaster.Application.DTOs.Coaches
{
    public class CoachDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Nationality { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public int ExperienceYears { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; } = null!;
    }
}