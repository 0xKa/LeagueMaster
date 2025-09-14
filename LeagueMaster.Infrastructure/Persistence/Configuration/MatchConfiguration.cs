using LeagueMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LeagueMaster.Infrastructure.Persistence.Configuration
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.Property(x => x.Location).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Stadium).IsRequired().HasMaxLength(50);

            builder.HasOne(m => m.HomeTeam)
                   .WithMany(t => t.HomeMatches)
                   .HasForeignKey(m => m.HomeTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.AwayTeam)
                   .WithMany(t => t.AwayMatches)
                   .HasForeignKey(m => m.AwayTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
