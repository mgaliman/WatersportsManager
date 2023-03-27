using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WatersportsManager.Domain;

namespace WatersportsManager.Application.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(nameof(Person));

            builder.HasMany(p => p.Reservations)
                .WithOne(b => b.Person)
                .HasForeignKey(b => b.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Reviews)
                .WithOne(r => r.Person)
                .HasForeignKey(r => r.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(person => person.Location)
                .WithMany(location => location.People)
                .HasForeignKey(person => person.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(person => person.Role)
                .WithMany(role => role.People)
                .HasForeignKey(person => person.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(x => x.Id);
        }
    }
}
