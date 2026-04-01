using System;
using System.Collections.Generic;

namespace Models.Entities.Domain;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public int CargoId { get; set; }

    public int SedeId { get; set; }

    public int TipoContratoId { get; set; }

    public int? TipoEventoEmpleadoId { get; set; }

    public int? JefeId { get; set; }

    public string TipoIdentificacion { get; set; } = null!;

    public string NumeroIdentificacion { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string? Genero { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public DateOnly FechaIngresoDirecto { get; set; }

    public DateOnly? FechaIngresoTemporal { get; set; }

    public bool Activo { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public DateOnly? FechaRetiro { get; set; }

    public string? MotivoRetiro { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Cargo Cargo { get; set; } = null!;

    public virtual ICollection<EventoEmpleado> EventoEmpleadoAutorizadoPorEmpleados { get; set; } = new List<EventoEmpleado>();

    public virtual ICollection<EventoEmpleado> EventoEmpleadoEmpleados { get; set; } = new List<EventoEmpleado>();

    public virtual ICollection<HoraExtra> HoraExtras { get; set; } = new List<HoraExtra>();

    public virtual ICollection<HorarioLaboral> HorarioLaboralEmpleados { get; set; } = new List<HorarioLaboral>();

    public virtual ICollection<HorarioLaboral> HorarioLaboralProgramadoPorEmpleados { get; set; } = new List<HorarioLaboral>();

    public virtual ICollection<Empleado> InverseJefe { get; set; } = new List<Empleado>();

    public virtual Empleado? Jefe { get; set; }

    public virtual Sede Sede { get; set; } = null!;

    public virtual TipoContrato TipoContrato { get; set; } = null!;

    public virtual TipoEventoEmpleado? TipoEventoEmpleado { get; set; }
}
