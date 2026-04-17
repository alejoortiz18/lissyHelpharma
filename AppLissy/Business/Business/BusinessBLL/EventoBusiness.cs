using Business.Interfaces;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Models.Dto;
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

        public bool Add(EventoEmpleado evento, byte[] archivoBytes)
        {
            try
            {
                bool result = _event.Add(evento);
                //falta envio del correo con el archivo adjunto
                return result;
            }
            catch
            {
                return false;
            }
        }

        public List<EventoEmpleado> GetAllEventos(int empleadoId)
        {
            return _event.GetAllEventos(empleadoId);
        }
    }
}
