using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Dto;
using Models.Entities.Domain;

namespace Data.Repository.Empleado
{
    public class EmpleadoRespository : IEmpleadoRespository
    {
        private readonly AppDbContext _context;
        public EmpleadoRespository(AppDbContext context)
        {
            _context = context;
        }

        public List<EmpleadoDto> EmpleadoResponseGetAll()
        {
            try
            {
                var sql = @"
                SELECT E.EmpleadoId AS Id,
                       E.TipoIdentificacion,
                       E.NumeroIdentificacion,
                       E.Nombres,
                       E.Apellidos,
                       E.Correo,
                       E.FechaIngreso,
                       E.SuperNum,
                       E.FechaRetiro,
                       E.FechaNacimiento,
                       E.Activo,
                       C.Nombre AS Cargo,
                       S.Nombre AS Sede,
                       S.Ciudad,
                       TC.Nombre AS TipoContrato
                FROM dbo.Empleado E
                INNER JOIN dbo.Cargo C ON E.CargoId = C.CargoId
                INNER JOIN dbo.Sede S ON E.SedeId = S.SedeId
                INNER JOIN dbo.TipoContrato TC ON E.TipoContratoId = TC.TipoContratoId";

                var response = _context.EmpleadoDto
                        .FromSqlRaw(sql)
                        .AsNoTracking()
                        .ToList();

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar empleados: " + ex.Message);
            }
        }

        public List<Models.Entities.Domain.Empleado> EmpleadoGetAll()
        {
            try
            {
                var response = _context.Empleados
                        .Include(e => e.Cargo)
                        .Include(e => e.Sede)
                        .Include(e => e.TipoContrato)
                        .AsNoTracking()
                        .ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar empleados: " + ex.Message);
            }

        }
}
