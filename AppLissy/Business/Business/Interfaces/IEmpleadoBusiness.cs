using Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IEmpleadoBusiness
    {
        List<EmpleadoDto> EmpleadoResponseGetAll();
    }
}
