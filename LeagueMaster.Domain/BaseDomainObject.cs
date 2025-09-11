
namespace LeagueMaster.Domain
{
    public class BaseDomainObject
    {
        public int Id { get; set; }
        
        //audit fields
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
