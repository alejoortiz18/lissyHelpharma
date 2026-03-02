using System;
using System.Collections.Generic;

namespace Models.Entities.Domain;

public partial class TipoPermiso
{
    public int TipoPermisoId { get; set; }

    public string Nombre { get; set; } = null!;

    public bool RequiereSoporte { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
