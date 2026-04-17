using Business.Interfaces;
using Data.Interfaces;
using Helper;
using Models.Dto;
using Models.Entities.Domain;
using Models.Models;

namespace Business.BusinessBLL
{
    public class EmpleadoBusiness : IEmpleadoBusiness
    {
        private readonly IEmpleadoRespository _empleadoRespository;
        private readonly ICargosRepository _cargosRepository;
        private readonly ISedesRepository _sedeRepository;
        private readonly IContratoRepository _tipoContratoRepository;

        public EmpleadoBusiness(IEmpleadoRespository emp
            , ICargosRepository cargo
            , ISedesRepository sede
            , IContratoRepository contrato)
        {
            _empleadoRespository = emp;
            _cargosRepository = cargo;
            _sedeRepository = sede;
            _tipoContratoRepository = contrato;
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

        public Empleado EmpleadoGetById(int id)
        {
            try
            {
                return _empleadoRespository.EmpleadoGetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener empleado: " + ex.Message);
            }
        }

        public Empleado GetEmpleadoCompleto(int id)
        {
            try
            {
                return _empleadoRespository.GetEmpleadoCompleto(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener empleado completo: " + ex.Message);
            }
        }

        public bool Add(EmpleadoDto model)
        {
            try
            {
              //  var (hash, salt) = PasswordHelper.EncrypPassword(model.Password);

                var empleado = new Empleado
                {
                    TipoIdentificacion = model.TipoIdentificacion,
                    NumeroIdentificacion = model.NumeroIdentificacion,
                    Nombres = model.Nombres,
                    Apellidos = model.Apellidos,
                    Correo = model.Correo,
                    FechaNacimiento = model.FechaNacimiento.HasValue
                        ? DateOnly.FromDateTime(model.FechaNacimiento.Value)
                        : DateOnly.FromDateTime(DateTime.Now),

                    FechaIngresoDirecto = model.FechaIngreso.HasValue
                        ? DateOnly.FromDateTime(model.FechaIngreso.Value)
                        : DateOnly.FromDateTime(DateTime.Now),

                    Activo = true,

                    //PasswordHash = hash,
                    //PasswordSalt = salt,

                    FechaCreacion = DateTime.Now,

                    CargoId = 1,
                    SedeId = 1,
                    TipoContratoId = 1
                };

                return _empleadoRespository.Add(empleado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear empleado: " + ex.Message);
            }
        }

        public Task<bool> GenerarPasswords()
        {
            try
            {
                return _empleadoRespository.GenerarPasswords();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar passwords: " + ex.Message);
            }
        }
    }
}
