using LeagueMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LeagueMaster.Infrastructure.Persistence.Configuration
{
    public class LeagueConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Country).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Season).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedAt).IsRequired();

            builder.HasMany(x => x.Teams)
                   .WithOne(x => x.League)
                   .HasForeignKey(x => x.LeagueId)
                   .OnDelete(DeleteBehavior.Restrict);

            //builder.HasData (
            //    new League { Id = 1, Name = "Reda League", Country = "Earth", Season = "2025", CreatedAt = new DateTime(2025, 09, 08, 00, 00, 00) }
            //);
        }
    }
}
