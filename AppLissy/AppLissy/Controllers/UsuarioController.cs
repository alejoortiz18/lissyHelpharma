using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppLissy.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IEmpleadoBusiness _empleado;
        public UsuarioController(IEmpleadoBusiness emp)
        {
                _empleado = emp;
        }

        public IActionResult DetalleEmpleado(int id)
        {
            var empleado = _empleado.GetEmpleadoCompleto(id);
            return View(empleado);
        }
    }
}
