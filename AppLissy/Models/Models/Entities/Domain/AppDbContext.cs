using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities.Domain;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EstadoSolicitud> EstadoSolicituds { get; set; }

    public virtual DbSet<EventoEmpleado> EventoEmpleados { get; set; }

    public virtual DbSet<HoraExtra> HoraExtras { get; set; }

    public virtual DbSet<HorarioLaboral> HorarioLaborals { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<TipoContrato> TipoContratos { get; set; }

    public virtual DbSet<TipoEventoEmpleado> TipoEventoEmpleados { get; set; }

    public virtual DbSet<TipoHoraExtra> TipoHoraExtras { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GestionPersonalDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.CargoId).HasName("PK__Cargo__B4E665CDD7DBAC38");

            entity.ToTable("Cargo");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE910DF19A769");

            entity.ToTable("Empleado");

            entity.HasIndex(e => e.NumeroIdentificacion, "UQ__Empleado__FCA68D91AD6476A3").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Genero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MotivoRetiro)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NumeroIdentificacion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoIdentificacion)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Cargo).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleado_Cargo");

            entity.HasOne(d => d.Jefe).WithMany(p => p.InverseJefe)
                .HasForeignKey(d => d.JefeId)
                .HasConstraintName("FK_Empleado_Jefe");

            entity.HasOne(d => d.Sede).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.SedeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleado_Sede");

            entity.HasOne(d => d.TipoContrato).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.TipoContratoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleado_TipoContrato");
        });

        modelBuilder.Entity<EstadoSolicitud>(entity =>
        {
            entity.HasKey(e => e.EstadoSolicitudId).HasName("PK__EstadoSo__04D23718BAD6A528");

            entity.ToTable("EstadoSolicitud");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EventoEmpleado>(entity =>
        {
            entity.HasKey(e => e.EventoEmpleadoId).HasName("PK__EventoEm__0A06DD3425AACB06");

            entity.ToTable("EventoEmpleado");

            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(sysdatetime())", "DF__EventoEmp__Fecha__6383C8BA");
            entity.Property(e => e.FechaSolicitud).HasDefaultValueSql("(sysdatetime())", "DF__EventoEmp__Fecha__628FA481");
            entity.Property(e => e.Observacion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SoporteUrl)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.AutorizadoPorEmpleado).WithMany(p => p.EventoEmpleadoAutorizadoPorEmpleados)
                .HasForeignKey(d => d.AutorizadoPorEmpleadoId)
                .HasConstraintName("FK_EventoEmpleado_Autoriza");

            entity.HasOne(d => d.Empleado).WithMany(p => p.EventoEmpleadoEmpleados)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventoEmpleado_Empleado");

            entity.HasOne(d => d.EstadoSolicitud).WithMany(p => p.EventoEmpleados)
                .HasForeignKey(d => d.EstadoSolicitudId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventoEmpleado_Estado");

            entity.HasOne(d => d.TipoEventoEmpleado).WithMany(p => p.EventoEmpleados)
                .HasForeignKey(d => d.TipoEventoEmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventoEmpleado_Tipo");
        });

        modelBuilder.Entity<HoraExtra>(entity =>
        {
            entity.HasKey(e => e.HoraExtraId).HasName("PK__HoraExtr__BEE2480F0D57EB24");

            entity.ToTable("HoraExtra");

            entity.Property(e => e.CantidadHoras).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Justificacion)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.Empleado).WithMany(p => p.HoraExtras)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoraExtra_Empleado");

            entity.HasOne(d => d.EstadoSolicitud).WithMany(p => p.HoraExtras)
                .HasForeignKey(d => d.EstadoSolicitudId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoraExtra_Estado");

            entity.HasOne(d => d.TipoHoraExtra).WithMany(p => p.HoraExtras)
                .HasForeignKey(d => d.TipoHoraExtraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoraExtra_Tipo");
        });

        modelBuilder.Entity<HorarioLaboral>(entity =>
        {
            entity.HasKey(e => e.HorarioLaboralId).HasName("PK__HorarioL__AAA969010DA219E0");

            entity.ToTable("HorarioLaboral");

            entity.Property(e => e.Activo).HasDefaultValue(true, "DF__HorarioLa__Activ__6D0D32F4");
            entity.Property(e => e.FechaInicio).HasDefaultValueSql("(getdate())", "DF__HorarioLa__Fecha__6C190EBB");

            entity.HasOne(d => d.Empleado).WithMany(p => p.HorarioLaboralEmpleados)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Horario_Empleado");

            entity.HasOne(d => d.ProgramadoPorEmpleado).WithMany(p => p.HorarioLaboralProgramadoPorEmpleados)
                .HasForeignKey(d => d.ProgramadoPorEmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Horario_ProgramadoPor");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.SedeId).HasName("PK__Sede__FD76DFDB43756ABC");

            entity.ToTable("Sede");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoContrato>(entity =>
        {
            entity.HasKey(e => e.TipoContratoId).HasName("PK__TipoCont__3E0E57876A614315");

            entity.ToTable("TipoContrato");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoEventoEmpleado>(entity =>
        {
            entity.HasKey(e => e.TipoEventoEmpleadoId).HasName("PK__TipoEven__760C5A450E747ACE");

            entity.ToTable("TipoEventoEmpleado");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoHoraExtra>(entity =>
        {
            entity.HasKey(e => e.TipoHoraExtraId).HasName("PK__TipoHora__A2DCE410A8EAC453");

            entity.ToTable("TipoHoraExtra");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
