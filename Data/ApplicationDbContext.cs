using System;
using System.Collections.Generic;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-F46GU5O;Initial Catalog=Hospital;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC2DC346E4D");

            entity.Property(e => e.AppointmentId).HasDefaultValueSql("(NEXT VALUE FOR [Appointment_Id])");
            entity.Property(e => e.DoctorId).HasColumnName("Doctor_Id");
            entity.Property(e => e.PatientName).HasMaxLength(20);

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__Appointme__Docto__3B75D760");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctors__2DC00EBF9E387EBE");

            entity.Property(e => e.DoctorName).HasMaxLength(20);
            entity.Property(e => e.Img).HasMaxLength(20);
            entity.Property(e => e.Specialization).HasMaxLength(20);
        });
        modelBuilder.HasSequence<int>("Appointment_Id");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
