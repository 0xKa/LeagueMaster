using LeagueMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LeagueMaster.Infrastructure.Persistence.Configuration
{
    public class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.Property(x => x.Nationality).IsRequired().HasMaxLength(40);

            builder.HasOne(c => c.Team)
                   .WithOne(t => t.Coach)
                   .HasForeignKey<Coach>(c => c.TeamId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
