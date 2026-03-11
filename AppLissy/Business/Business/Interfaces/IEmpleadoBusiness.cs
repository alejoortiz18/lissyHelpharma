using Models.Entities.Domain;

namespace Business.Interfaces
{
    public interface IEmpleadoBusiness
    {
        List<Empleado> EmpleadoResponseGetAll();
    }
}
