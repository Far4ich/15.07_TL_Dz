using Microsoft.EntityFrameworkCore;
using MedicineApi.Infrastructure.UoW;
using MedicineApi.Domain;
using MedicineApi.Infrastructure.Data.HospitalModel.EntityCofigurations;

namespace MedicineApi.Infrastructure.Data
{
    public class MedicineContext : DbContext, IUnitOfWork
    {
        public MedicineContext(DbContextOptions<MedicineContext> options) : base(options)
        {
        }

        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new HospitalMap());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
