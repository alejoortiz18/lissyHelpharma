using Models.Dto;
using Models.Entities.Domain;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IEmpleadoRespository
    {
        List<Empleado> EmpleadoResponseGetAll();
        Paginacion<Empleado> EmpleadoResponseGetAll(int pagina, int cantidad);
        Empleado EmpleadoGetById(int id);
        Empleado GetEmpleadoCompleto(int id);
    }
}
