using System;
using System.Collections.Generic;

namespace Models.Entities.Domain;

public partial class HorarioLaboral
{
    public int HorarioLaboralId { get; set; }

    public int EmpleadoId { get; set; }

    public int ProgramadoPorEmpleadoId { get; set; }

    public TimeOnly HoraEntrada { get; set; }

    public TimeOnly HoraSalida { get; set; }

    public bool TrabajaFinSemana { get; set; }

    public bool TrabajaFestivo { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public bool Activo { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Empleado ProgramadoPorEmpleado { get; set; } = null!;
}
