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


        public IActionResult Index()
        {
            var empleados = _empBus.EmpleadoResponseGetAll();
           
            return View(empleados);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
