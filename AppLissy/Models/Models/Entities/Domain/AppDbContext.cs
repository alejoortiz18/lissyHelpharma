using Microsoft.EntityFrameworkCore;
using Models.Dto;
using System;
using System.Collections.Generic;

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

    public virtual DbSet<HoraExtra> HoraExtras { get; set; }

    public virtual DbSet<HorarioLaboral> HorarioLaborals { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<TipoContrato> TipoContratos { get; set; }

    public virtual DbSet<TipoHoraExtra> TipoHoraExtras { get; set; }

    public virtual DbSet<TipoPermiso> TipoPermisos { get; set; }

    public virtual DbSet<Vacacione> Vacaciones { get; set; }

    public DbSet<EmpleadoDto> EmpleadoDto { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GestionPersonalDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmpleadoDto>().HasNoKey();

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.CargoId).HasName("PK__Cargo__B4E665CD2945B0D2");

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
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE9104223CE4E");

            entity.ToTable("Empleado");

            entity.HasIndex(e => e.NumeroIdentificacion, "IX_Empleado_NumeroIdentificacion");

            entity.HasIndex(e => e.NumeroIdentificacion, "UQ__Empleado__FCA68D91A154C41B").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true, "DF__Empleado__Activo__6FE99F9F");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysdatetime())", "DF__Empleado__FechaC__70DDC3D8");
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
            entity.HasKey(e => e.EstadoSolicitudId).HasName("PK__EstadoSo__04D23718216DD362");

            entity.ToTable("EstadoSolicitud");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HoraExtra>(entity =>
        {
            entity.HasKey(e => e.HoraExtraId).HasName("PK__HoraExtr__BEE2480F2B1C5602");

            entity.ToTable("HoraExtra");

            entity.HasIndex(e => e.EmpleadoId, "IX_HoraExtra_Empleado");

            entity.HasIndex(e => e.Fecha, "IX_HoraExtra_Fecha");

            entity.Property(e => e.CantidadHoras).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(sysdatetime())", "DF__HoraExtra__Fecha__06CD04F7");
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
            entity.HasKey(e => e.HorarioLaboralId).HasName("PK__HorarioL__AAA9690175D25052");

            entity.ToTable("HorarioLaboral");

            entity.Property(e => e.Activo).HasDefaultValue(true);

            entity.HasOne(d => d.Empleado).WithMany(p => p.HorarioLaborals)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Horario_Empleado");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.PermisoId).HasName("PK__Permiso__96E0C7232E37B733");

            entity.ToTable("Permiso");

            entity.HasIndex(e => e.EmpleadoId, "IX_Permiso_Empleado");

            entity.Property(e => e.FechaSolicitud).HasDefaultValueSql("(sysdatetime())", "DF__Permiso__FechaSo__01142BA1");
            entity.Property(e => e.Observacion)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.Empleado).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permiso_Empleado");

            entity.HasOne(d => d.EstadoSolicitud).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.EstadoSolicitudId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permiso_Estado");

            entity.HasOne(d => d.TipoPermiso).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.TipoPermisoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permiso_Tipo");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.SedeId).HasName("PK__Sede__FD76DFDB3219B271");

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
            entity.HasKey(e => e.TipoContratoId).HasName("PK__TipoCont__3E0E578736770E92");

            entity.ToTable("TipoContrato");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoHoraExtra>(entity =>
        {
            entity.HasKey(e => e.TipoHoraExtraId).HasName("PK__TipoHora__A2DCE4100E8FBCB2");

            entity.ToTable("TipoHoraExtra");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoPermiso>(entity =>
        {
            entity.HasKey(e => e.TipoPermisoId).HasName("PK__TipoPerm__6A7B92D2B4A6698F");

            entity.ToTable("TipoPermiso");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vacacione>(entity =>
        {
            entity.HasKey(e => e.VacacionesId).HasName("PK__Vacacion__DC314980BC203B4B");

            entity.HasIndex(e => e.EmpleadoId, "IX_Vacaciones_Empleado");

            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(sysdatetime())", "DF__Vacacione__Fecha__7C4F7684");
            entity.Property(e => e.Observacion)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.Empleado).WithMany(p => p.Vacaciones)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vacaciones_Empleado");

            entity.HasOne(d => d.EstadoSolicitud).WithMany(p => p.Vacaciones)
                .HasForeignKey(d => d.EstadoSolicitudId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vacaciones_Estado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
