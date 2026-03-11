using System;
using System.Collections.Generic;

namespace Models.Entities.Domain;

public partial class EstadoSolicitud
{
    public int EstadoSolicitudId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<EventoEmpleado> EventoEmpleados { get; set; } = new List<EventoEmpleado>();

    public virtual ICollection<HoraExtra> HoraExtras { get; set; } = new List<HoraExtra>();
}
