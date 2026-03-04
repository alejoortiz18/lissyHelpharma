using Business.Interfaces;
using Data.Interfaces;
using Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessBLL
{
    public class EmpleadoBusiness : IEmpleadoBusiness
    {
        private readonly IEmpleadoRespository _empleadoRespository;

        public EmpleadoBusiness(IEmpleadoRespository emp)
        {
            _empleadoRespository = emp;
        }


        public List<EmpleadoDto> EmpleadoResponseGetAll()
        {
            try
            {
                return _empleadoRespository.EmpleadoResponseGetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener empleados: " + ex.Message);
            }
        }

    }
}
