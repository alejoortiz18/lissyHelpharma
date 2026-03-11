using System;
using System.Collections.Generic;

namespace Models.Entities.Domain;

public partial class HoraExtra
{
    public int HoraExtraId { get; set; }

    public int EmpleadoId { get; set; }

    public int TipoHoraExtraId { get; set; }

    public int EstadoSolicitudId { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal CantidadHoras { get; set; }

    public string? Justificacion { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual EstadoSolicitud EstadoSolicitud { get; set; } = null!;

    public virtual TipoHoraExtra TipoHoraExtra { get; set; } = null!;
}
