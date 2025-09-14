using LeagueMaster.Domain;
using LeagueMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LeagueMaster.Infrastructure.Persistence
{
    public class LeagueMasterDbContext : DbContext
    {
        public LeagueMasterDbContext(DbContextOptions<LeagueMasterDbContext> options) : base(options) { }

        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeagueMasterDbContext).Assembly);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseDomainObject && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseDomainObject)entityEntry.Entity).UpdatedAt = DateTime.Now;
                
                if (entityEntry.State == EntityState.Added)
                    ((BaseDomainObject)entityEntry.Entity).CreatedAt = DateTime.Now;
            }


            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
