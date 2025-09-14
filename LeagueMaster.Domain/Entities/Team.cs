
namespace LeagueMaster.Domain.Entities
{
    public class Team : BaseDomainObject
    {
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public int FoundedYear { get; set; }
        public string? Stadium { get; set; }

        public int LeagueId { get; set; }
        public League League { get; set; } = null!;

        public ICollection<Player> Players { get; set; } = new List<Player>();

    }
}
