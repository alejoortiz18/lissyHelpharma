using System;
using System.Collections.Generic;

namespace Models.Entities.Domain;

public partial class TipoContrato
{
    public int TipoContratoId { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
