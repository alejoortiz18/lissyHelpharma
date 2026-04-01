using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Dto;

namespace AppLissy.Models.Empleado
{
    public class EmpleadoCreateViewModel
    {
        public EmpleadoDto Empleado { get; set; }

        public List<SelectListItem> Cargos { get; set; }
        public List<SelectListItem> Sedes { get; set; }
        public List<SelectListItem> TiposContrato { get; set; }

        public EmpleadoCreateViewModel()
        {
            Empleado = new EmpleadoDto();
            Cargos = new List<SelectListItem>();
            Sedes = new List<SelectListItem>();
            TiposContrato = new List<SelectListItem>();
        }
    }
}
