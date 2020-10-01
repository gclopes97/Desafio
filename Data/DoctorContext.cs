using DesafioApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DesafioApi.Data
{
    public class DoctorContext : DbContext
    {
        public DoctorContext(DbContextOptions<DoctorContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
            .Property(e => e.Especialidades)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
