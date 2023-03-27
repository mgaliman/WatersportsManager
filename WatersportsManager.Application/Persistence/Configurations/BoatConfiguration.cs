using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WatersportsManager.Domain;

namespace WatersportsManager.Application.Persistence.Configurations
{
    public class BoatConfiguration
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable(nameof(Reservation));

            builder.HasOne(boat => boat.Person)
                .WithMany(person => person.Reservations)
                .HasForeignKey(boat => boat.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(boat => boat.BoatType)
                .WithMany(boatType => boatType.Reservations)
                .HasForeignKey(boatType => boatType.BoatTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(boat => boat.Location)
                .WithMany(location => location.Reservations)
                .HasForeignKey(boat => boat.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.Reviews)
                .WithOne(r => r.Reservation)
                .HasForeignKey(r => r.ResevationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(x => x.Id);
        }
    }
}
