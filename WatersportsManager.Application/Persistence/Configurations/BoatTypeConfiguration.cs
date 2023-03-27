using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WatersportsManager.Domain;

namespace WatersportsManager.Application.Persistence.Configurations
{
    public class BoatTypeConfiguration : IEntityTypeConfiguration<BoatType>
    {
        public void Configure(EntityTypeBuilder<BoatType> builder)
        {
            builder.ToTable(nameof(BoatType));

            builder.HasOne(boatType => boatType.Price)
                .WithMany(price => price.BoatTypes)
                .HasForeignKey(boatType => boatType.PriceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(x => x.Id);
        }
    }
}
