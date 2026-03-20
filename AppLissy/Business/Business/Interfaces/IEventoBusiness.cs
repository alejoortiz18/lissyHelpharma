using Models.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IEventoBusiness
    {
        Empleado GetByEmpleadoId(int id);
        List<TipoEventoEmpleado> GetAll();
    }
}
