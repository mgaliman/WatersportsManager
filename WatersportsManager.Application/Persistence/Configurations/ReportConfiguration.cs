using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WatersportsManager.Domain;

namespace WatersportsManager.Application.Persistence.Configurations
{
    public class ReportConfiguration
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable(nameof(Report));

            builder.HasOne(report => report.Person)
                .WithMany(person => person.Reports)
                .HasForeignKey(report => report.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(report => report.PriorityType)
                .WithMany(person => person.Reports)
                .HasForeignKey(review => review.PriorityTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(x => x.Id);
        }
    }
}
