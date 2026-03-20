using Business.Interfaces;
using Data.Interfaces;
using Models.Entities.Domain;

namespace Business.BusinessBLL
{
    public class EventoBusiness : IEventoBusiness
    {
        private readonly IEventoRepository _event;

        public EventoBusiness(IEventoRepository evento)
        {
            _event = evento;
        }

        public Empleado GetByEmpleadoId(int id)
        {
            return _event.GetByEmpleadoId(id);
        }

        public List<TipoEventoEmpleado> GetAll()
        {
            return _event.GetAll();
        }

    }
}
