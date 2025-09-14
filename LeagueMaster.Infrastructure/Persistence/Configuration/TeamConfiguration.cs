using LeagueMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LeagueMaster.Infrastructure.Persistence.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.City).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Stadium).IsRequired().HasMaxLength(50); //

            builder.HasOne(x => x.League)
                   .WithMany(x => x.Teams)
                   .HasForeignKey(x => x.LeagueId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Players)
                   .WithOne(x => x.Team)
                   .HasForeignKey(x => x.TeamId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
