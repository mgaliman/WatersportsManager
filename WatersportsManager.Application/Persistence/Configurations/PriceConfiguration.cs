using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WatersportsManager.Domain;

namespace WatersportsManager.Application.Persistence.Configurations
{
    public class PriceConfiguration
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable(nameof(Price));

            builder.HasOne(price => price.TimeType)
                .WithMany(timeType => timeType.Prices)
                .HasForeignKey(boatType => boatType.TimeTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(x => x.Id);
        }
    }
}
