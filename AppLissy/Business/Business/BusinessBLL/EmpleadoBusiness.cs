using Business.Interfaces;
using Data.Interfaces;
using Models.Dto;
using Models.Entities.Domain;
using Models.Models;
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


        public List<Empleado> EmpleadoResponseGetAll()
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

        public Paginacion<Empleado> EmpleadoResponseGetAll(int pagina, int cantidad)
        {
            try
            {
                return _empleadoRespository.EmpleadoResponseGetAll(pagina, cantidad);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener empleados: " + ex.Message);
            }
        }
    }
}
