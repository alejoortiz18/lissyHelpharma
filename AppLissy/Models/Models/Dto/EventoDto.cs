using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class EventoDto : IValidatableObject
    {
        public int TipoEventoEmpleadoId { get; set; }

        public int EstadoSolicitudId { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        public DateOnly? FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha final es obligatoria")]
        public DateOnly? FechaFin { get; set; }

        [StringLength(500, ErrorMessage = "Máximo 500 caracteres")]
        public string? Observacion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public string? SoporteUrl { get; set; }

        // 🔥 VALIDACIONES PERSONALIZADAS
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var hoy = DateOnly.FromDateTime(DateTime.Now);

            if (FechaInicio.HasValue)
            {
                // ❌ Fecha inicio menor a hoy
                if (FechaInicio.Value < hoy)
                {
                    yield return new ValidationResult(
                        "La fecha de inicio no puede ser menor a hoy",
                        new[] { nameof(FechaInicio) }
                    );
                }
            }

            if (FechaInicio.HasValue && FechaFin.HasValue)
            {
                // ❌ Fecha fin menor a inicio
                if (FechaFin.Value < FechaInicio.Value)
                {
                    yield return new ValidationResult(
                        "La fecha final no puede ser menor a la fecha inicial",
                        new[] { nameof(FechaFin) }
                    );
                }
            }
        }
    }
}
