using MedicineApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicineApi.Infrastructure.Data.DoctorModel.EntityCofigurations
{
    public class DoctorlMap : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name);
            builder.Property(x => x.HospitalId);
            builder.Property(x => x.TelephoneNumber);
        }
    }
}
