using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Domain;

namespace Data.Repository.Evento
{
    public class EventoRepository : IEventoRepository
    {
        private readonly AppDbContext _context;
        public EventoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<TipoEventoEmpleado> GetAll()
        {
            var events = _context.TipoEventoEmpleados.ToList();
            return events;
        }

        public Models.Entities.Domain.Empleado GetByEmpleadoId(int id)
        {
            var events = _context.Empleados
                .Include(x=>x.EventoEmpleadoEmpleados)
                    .ThenInclude(x=>x.TipoEventoEmpleado)
                .Include(x=>x.Cargo)
                .Include(x=>x.TipoEventoEmpleado)
                .Include(x => x.TipoContrato)
                .Include(x => x.Sede)
                .Where(x => x.EmpleadoId == id)
                .FirstOrDefault();

            return events;
        }

        public bool Add(EventoEmpleado evento)
        {
            try
            {
                _context.EventoEmpleados.Add(evento);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
