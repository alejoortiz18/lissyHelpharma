using AutoMapper;
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
        private readonly IWebHostEnvironment _webHost;
        private readonly IMapper _mapper;

        public EventosController(IEmpleadoBusiness empB,
            IEventoBusiness eventBus, 
            ISolicitudesBusiness solicBus,
            IWebHostEnvironment env,
            IMapper mapper)
        {
            _empBus = empB;
            _eventBus = eventBus;
            _solicBus = solicBus;
            _webHost = env;
            _mapper = mapper;
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventoDto model, IFormFile archivo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    CargarCombos();
                    return View("Index", model);
                }

                model.FechaRegistro = DateTime.Now;
                model.FechaSolicitud = DateTime.Now;

                byte[]? archivoBytes = null;

                if (archivo != null && archivo.Length > 0)
                {
                    using var ms = new MemoryStream();
                    await archivo.CopyToAsync(ms);
                    archivoBytes = ms.ToArray();
                }

                var entidad = _mapper.Map<EventoEmpleado>(model);

                bool resultAdd = _eventBus.Add(entidad, archivoBytes);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                CargarCombos();
                return View("Index", model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VerEventos(int EmpleadoId)
        {
            var eventos = _eventBus.GetAllEventos(EmpleadoId);
            return View(eventos);
        }

        private void CargarCombos()
        {
            ViewBag.Eventos = _eventBus.GetAll();
            ViewBag.Solicitudes = _solicBus.GetAll();
        }
    }

}

