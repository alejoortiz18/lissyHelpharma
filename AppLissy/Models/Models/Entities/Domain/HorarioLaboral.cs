using System;
using System.Collections.Generic;

namespace Models.Entities.Domain;

public partial class HorarioLaboral
{
    public int HorarioLaboralId { get; set; }

    public int EmpleadoId { get; set; }

    public TimeOnly HoraEntrada { get; set; }

    public TimeOnly HoraSalida { get; set; }

    public bool TrabajaFinSemana { get; set; }

    public bool TrabajaFestivo { get; set; }

    public bool Activo { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;
}
