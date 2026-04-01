using Models.Dto;
using Models.Entities.Domain;
using Models.Models;

namespace Business.Interfaces
{
    public interface IEmpleadoBusiness
    {
        List<Empleado> EmpleadoResponseGetAll();
        Paginacion<Empleado> EmpleadoResponseGetAll(int pagina, int cantidad);
        Empleado EmpleadoGetById(int id);
        Empleado GetEmpleadoCompleto(int id);
        bool Add(EmpleadoDto model);
    }
}
