using Models.Entities.Domain;

namespace Data.Interfaces
{
    public interface IEventoRepository
    {
        List<TipoEventoEmpleado> GetAll();
        Empleado GetByEmpleadoId(int id);
        bool Add(EventoEmpleado evento);
        List<EventoEmpleado> GetAllEventos(int empleadoId);
    }
}
