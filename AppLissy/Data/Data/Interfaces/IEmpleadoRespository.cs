using Models.Dto;
using Models.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IEmpleadoRespository
    {
        List<Empleado> EmpleadoResponseGetAll();
    }
}
