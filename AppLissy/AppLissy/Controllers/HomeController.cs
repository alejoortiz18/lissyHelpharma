using AppLissy.Common.Security;
using AppLissy.Models;
using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppLissy.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public readonly IEmpleadoBusiness _empBus;
        private readonly CurrentUser _currentUser;

        public HomeController(IEmpleadoBusiness empB, CurrentUser currentUser)
        {
            _empBus = empB;
            _currentUser = currentUser;
        }

        public IActionResult Index(int pagina = 1)
        {
            int registrosPorPagina = 10;

            var usuarioId = _currentUser.UsuarioId;
            var nombre = _currentUser.Nombre;

            var empleados = _empBus.EmpleadoResponseGetAll(pagina, registrosPorPagina);

            return View(empleados);
        }

        public IActionResult Detalle(int id)
        {
            var empleado = _empBus.EmpleadoGetById(id);
            return View(empleado);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}