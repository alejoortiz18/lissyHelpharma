using Models.Entities.Domain;
using Models.Models;

namespace Data.Interfaces
{
    public interface IEmpleadoRespository
    {
        List<Empleado> EmpleadoResponseGetAll();
        Paginacion<Empleado> EmpleadoResponseGetAll(int pagina, int cantidad);
        Empleado EmpleadoGetById(int id);
        Empleado GetEmpleadoCompleto(int id);
        bool Add(Empleado empleado);

        List<Empleado> GetAll();
        Task<Empleado> ObtenerPorCorreo(string correo);
        Task<bool> GenerarPasswords();
    }
}
