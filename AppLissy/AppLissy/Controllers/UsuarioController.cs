using AppLissy.Models.Empleado;
using Business.Interfaces;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Dto;

namespace AppLissy.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IEmpleadoBusiness _empleado;
        private readonly IUsuarioBusiness _usBus;

        public UsuarioController(IEmpleadoBusiness emp, IUsuarioBusiness user)
        {
                _empleado = emp;
            _usBus = user;
        }


        public IActionResult Create()
        {
            var data = _usBus.Create();

            var model = new EmpleadoCreateViewModel
            {
                Empleado = new EmpleadoDto(),

                Cargos = data.Cargos.Select(x => new SelectListItem
                {
                    Value = x.CargoId.ToString(),
                    Text = x.Nombre
                }).ToList(),

                Sedes = data.Sedes.Select(x => new SelectListItem
                {
                    Value = x.SedeId.ToString(),
                    Text = x.Nombre
                }).ToList(),

                TiposContrato = data.TiposContrato.Select(x => new SelectListItem
                {
                    Value = x.TipoContratoId.ToString(),
                    Text = x.Nombre
                }).ToList()
            };

            return View(model);
        }

        public IActionResult DetalleEmpleado(int id)
        {
            var empleado = _empleado.GetEmpleadoCompleto(id);
            return View(empleado);
        }
    }
}
