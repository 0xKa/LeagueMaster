using LeagueMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LeagueMaster.Infrastructure.Persistence
{
    public class LeagueMasterDbContext : DbContext
    {
        public LeagueMasterDbContext(DbContextOptions<LeagueMasterDbContext> options) : base(options) { }

        public DbSet<League> Leagues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeagueMasterDbContext).Assembly);

        }


    }
}
