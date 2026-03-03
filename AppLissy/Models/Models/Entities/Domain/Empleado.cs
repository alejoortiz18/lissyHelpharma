using System;
using System.Collections.Generic;

namespace Models.Entities.Domain;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public int CargoId { get; set; }

    public int SedeId { get; set; }

    public int TipoContratoId { get; set; }

    public string TipoIdentificacion { get; set; } = null!;

    public string NumeroIdentificacion { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string? Genero { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public bool? SuperNum { get; set; }

    public bool Activo { get; set; }

    public DateOnly? FechaRetiro { get; set; }

    public string? MotivoRetiro { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Cargo Cargo { get; set; } = null!;

    public virtual ICollection<HoraExtra> HoraExtras { get; set; } = new List<HoraExtra>();

    public virtual ICollection<HorarioLaboral> HorarioLaborals { get; set; } = new List<HorarioLaboral>();

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();

    public virtual Sede Sede { get; set; } = null!;

    public virtual TipoContrato TipoContrato { get; set; } = null!;

    public virtual ICollection<Vacacione> Vacaciones { get; set; } = new List<Vacacione>();
}
