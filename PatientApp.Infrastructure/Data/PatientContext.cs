using PatientApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PatientApp.Infrastructure.Data;

public class PatientContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<MeetingType> MeetingTypes { get; set; }

    public PatientContext(DbContextOptions<PatientContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Patient>()
            .HasMany(p => p.Appointments)
            .WithOne(a => a.Patient)
            .HasForeignKey(a => a.PatientId);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.MeetingType)
            .WithMany()
            .HasForeignKey(a => a.MeetingTypeId);

    }
}