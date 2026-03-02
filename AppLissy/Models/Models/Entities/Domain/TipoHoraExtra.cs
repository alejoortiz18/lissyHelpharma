using System;
using System.Collections.Generic;

namespace Models.Entities.Domain;

public partial class TipoHoraExtra
{
    public int TipoHoraExtraId { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<HoraExtra> HoraExtras { get; set; } = new List<HoraExtra>();
}
