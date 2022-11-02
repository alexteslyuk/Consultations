using Consultations.Configurations;
using Consultations.Models;
using Microsoft.EntityFrameworkCore;

namespace Consultations
{
    public class DataContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Consultation> Consultations { get; set; }



        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new ConsultationConfiguration());
        }
    }
}
