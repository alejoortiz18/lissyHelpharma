using System;
using System.Collections.Generic;

namespace Models.Entities.Domain;

public partial class EstadoSolicitud
{
    public int EstadoSolicitudId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<HoraExtra> HoraExtras { get; set; } = new List<HoraExtra>();

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();

    public virtual ICollection<Vacacione> Vacaciones { get; set; } = new List<Vacacione>();
}
