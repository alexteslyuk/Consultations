using Consultations.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultations.Configurations
{
    public class ConsultationConfiguration : IEntityTypeConfiguration<Consultation>
    {
        public void Configure(EntityTypeBuilder<Consultation> builder)
        {
            builder.HasKey(с => с.Id);
            builder.HasOne(с => с.Patient)
                .WithMany(с => с.Consultations);
        }
    }
}
