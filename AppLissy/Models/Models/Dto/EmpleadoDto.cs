using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Dto
{
    public class EmpleadoDto
    {
        public string? TipoIdentificacion { get; set; }
        public string? NumeroIdentificacion { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Correo { get; set; }

        public DateTime? FechaIngreso { get; set; }
        public string? SuperNum { get; set; }
        public DateTime? FechaRetiro { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public bool? Activo { get; set; }

        public string? Cargo { get; set; }
        public string? Sede { get; set; }
        public string? Ciudad { get; set; }
        public string? TipoContrato { get; set; }
    }
}
