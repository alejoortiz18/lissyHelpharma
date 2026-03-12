using AppLissy.Models;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppLissy.Controllers
{
    public class HomeController : Controller
    {
        public readonly IEmpleadoBusiness _empBus;

        public HomeController(IEmpleadoBusiness empB)
        {
            _empBus = empB;
        }


        public IActionResult Index(int pagina = 1)
        {
            int registrosPorPagina = 10;

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
