using System;
using System.Collections.Generic;

namespace Models.Entities.Domain;

public partial class Vacacione
{
    public int VacacionesId { get; set; }

    public int EmpleadoId { get; set; }

    public int EstadoSolicitudId { get; set; }

    public DateOnly PeriodoInicio { get; set; }

    public DateOnly PeriodoFin { get; set; }

    public int DiasAsignados { get; set; }

    public int DiasTomados { get; set; }

    public DateOnly FechaInicioVacaciones { get; set; }

    public DateOnly FechaFinVacaciones { get; set; }

    public string? Observacion { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual EstadoSolicitud EstadoSolicitud { get; set; } = null!;
}
