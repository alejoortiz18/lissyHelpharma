using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLissy.Controllers
{
    public class EventosController : Controller
    {
       
        public readonly IEmpleadoBusiness _empBus;
        public readonly IEventoBusiness _eventBus;
        public EventosController(IEmpleadoBusiness empB, IEventoBusiness eventBus)
        {
            _empBus = empB;
            _eventBus = eventBus;
        }

        // GET: EventosController
        public ActionResult Index(int id)
        {
            int registrosPorPagina = 10;

            var empleados = _eventBus.GetByEmpleadoId(id);
            var eventos = _eventBus.GetAll();
            ViewBag.Eventos = eventos;

            return View(empleados);
        }

        // GET: EventosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventosController/Create
        public ActionResult Crear(int id)
        {
            return View();
        }

        // POST: EventosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
