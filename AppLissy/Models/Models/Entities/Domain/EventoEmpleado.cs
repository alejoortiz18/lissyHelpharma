using System;
using System.Collections.Generic;

namespace Models.Entities.Domain;

public partial class EventoEmpleado
{
    public int EventoEmpleadoId { get; set; }

    public int EmpleadoId { get; set; }

    public int TipoEventoEmpleadoId { get; set; }

    public int EstadoSolicitudId { get; set; }

    public int? AutorizadoPorEmpleadoId { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public string? Observacion { get; set; }

    public string? SoporteUrl { get; set; }

    public DateTime FechaSolicitud { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual Empleado? AutorizadoPorEmpleado { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual EstadoSolicitud EstadoSolicitud { get; set; } = null!;

    public virtual TipoEventoEmpleado TipoEventoEmpleado { get; set; } = null!;
}
