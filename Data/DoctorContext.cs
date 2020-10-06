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
            modelBuilder.Entity<DoctorSpecialty>()
            .HasKey(dc => new { dc.DoctorId, dc.SpecialtiesId });
            modelBuilder.Entity<DoctorSpecialty>()
                .HasOne(dc => dc.Doctor)
                .WithMany(d => d.DoctorSpecialties)
                .HasForeignKey(dc => dc.DoctorId);
            modelBuilder.Entity<DoctorSpecialty>()
                .HasOne(dc => dc.Specialty)
                .WithMany(s => s.DoctorSpecialties)
                .HasForeignKey(dc => dc.SpecialtiesId);
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<DoctorSpecialty> DoctorSpecialties { get; set; }
    }
}
