using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WatersportsManager.Domain;

namespace WatersportsManager.Application.Persistence.Configurations
{
    public class ReviewConfiguration
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable(nameof(Review));

            builder.HasOne(r => r.Person)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Reservation)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.ResevationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(x => x.Id);
        }
    }
}
