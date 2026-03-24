using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using Models.Entities.Domain;

namespace AppLissy.Controllers
{
    public class EventosController : Controller
    {
       
        public readonly IEmpleadoBusiness _empBus;
        public readonly IEventoBusiness _eventBus;
        public readonly ISolicitudesBusiness _solicBus;

        public EventosController(IEmpleadoBusiness empB, IEventoBusiness eventBus, ISolicitudesBusiness solicBus)
        {
            _empBus = empB;
            _eventBus = eventBus;
            _solicBus = solicBus;
        }

        // GET: EventosController
        public ActionResult Index(int id)
        {
            if (id == 0)
                return RedirectToAction("index","Home");
            int registrosPorPagina = 10;

            var empleados = _eventBus.GetByEmpleadoId(id);
            var eventos = _eventBus.GetAll();
            ViewBag.Eventos = eventos;
            ViewBag.Solicitudes = _solicBus.GetAll();

            return View(empleados);
        }




        // POST: EventosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventoDto model, IFormFile archivo)
        {
            try
            {
                // Ejemplo: setear datos automáticos
                model.FechaRegistro = DateTime.Now;
                model.FechaSolicitud = DateTime.Now;

                // Aquí guardas archivo si viene
                if (archivo != null && archivo.Length > 0)
                {
                    var ruta = Path.Combine("wwwroot/soportes", archivo.FileName);

                    using (var stream = new FileStream(ruta, FileMode.Create))
                    {
                        archivo.CopyTo(stream);
                    }

                    model.SoporteUrl = "/soportes/" + archivo.FileName;
                }

                // Guardar en BD aquí...

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) 
            {
                return View();
            }
        }


    }
}
