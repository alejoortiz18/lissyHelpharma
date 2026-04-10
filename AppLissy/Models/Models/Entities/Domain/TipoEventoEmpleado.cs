using System;
using System.Collections.Generic;

namespace Models.Entities.Domain;

public partial class TipoEventoEmpleado
{
    public int TipoEventoEmpleadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public bool RequiereSoporte { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<EventoEmpleado> EventoEmpleados { get; set; } = new List<EventoEmpleado>();
}
