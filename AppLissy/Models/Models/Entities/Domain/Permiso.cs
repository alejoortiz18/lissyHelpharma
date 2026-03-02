using System;
using System.Collections.Generic;

namespace Models.Entities.Domain;

public partial class Permiso
{
    public int PermisoId { get; set; }

    public int EmpleadoId { get; set; }

    public int TipoPermisoId { get; set; }

    public int EstadoSolicitudId { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public string? Observacion { get; set; }

    public DateTime FechaSolicitud { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual EstadoSolicitud EstadoSolicitud { get; set; } = null!;

    public virtual TipoPermiso TipoPermiso { get; set; } = null!;
}
