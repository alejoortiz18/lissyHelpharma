using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Domain;
using Models.Models;
using model = Models.Entities.Domain;

namespace Data.Repository.Empleado
{
    public class EmpleadoRespository : IEmpleadoRespository
    {
        private readonly AppDbContext _context;
        public EmpleadoRespository(AppDbContext context)
        {
            _context = context;
        }


        public List<model.Empleado> EmpleadoResponseGetAll()
        {
            try
            {
                var listUsuario = _context.Empleados
                    .Include(x => x.Cargo)
                    .Include(x => x.InverseJefe)
                    .Include(x => x.EventoEmpleadoEmpleados)
                         .AsNoTracking()
                         .ToList();

                return listUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar empleados: " + ex.Message);
            }
        }


        public Paginacion<model.Empleado> EmpleadoResponseGetAll(int pagina, int cantidad)
        {
            try
            {
                var query = _context.Empleados
                    .Include(x => x.Cargo)
                    .Include(x => x.InverseJefe)
                    .Include(x => x.EventoEmpleadoEmpleados)
                    .AsNoTracking();

                var total = query.Count();

                var empleados = query
                    .OrderBy(x => x.EmpleadoId)
                    .Skip((pagina - 1) * cantidad)
                    .Take(cantidad)
                    .ToList();

                return new Paginacion<model.Empleado>
                {
                    Datos = empleados,
                    TotalRegistros = total,
                    PaginaActual = pagina,
                    RegistrosPorPagina = cantidad
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar empleados: " + ex.Message);
            }
        }

        public model.Empleado EmpleadoGetById(int id)
        {
            try
            {
                var empleado = _context.Empleados
                    .Include(x => x.Cargo)
                    .Include(x => x.Jefe)
                        .ThenInclude(x => x.EventoEmpleadoEmpleados)
                    .Include(x => x.InverseJefe)
                        .ThenInclude(x => x.Cargo)
                    .Include(x => x.InverseJefe)
                        .ThenInclude(x => x.EventoEmpleadoEmpleados)
                    .Include(x => x.EventoEmpleadoEmpleados)
                    .AsNoTracking()
                    .FirstOrDefault(x => x.EmpleadoId == id);

                return empleado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar empleado: " + ex.Message);
            }
        }

        public model.Empleado GetEmpleadoCompleto(int id)
        {

            var emp = _context.Empleados.Where(e => e.EmpleadoId == id)
                .Include(e => e.Cargo)
                .Include(e => e.Sede)
                .Include(e => e.TipoContrato)
                .Include(e => e.Jefe)
                    .ThenInclude(j => j.Cargo)
                .Include(e => e.InverseJefe)
                    .ThenInclude(ij => ij.Cargo)
                .Include(e => e.EventoEmpleadoEmpleados)
                    .ThenInclude(z => z.TipoEventoEmpleado)
                .Include(e => e.EventoEmpleadoEmpleados)
                    .ThenInclude(q => q.AutorizadoPorEmpleado)
                .Include(e => e.HorarioLaboralEmpleados)
                .Include(e => e.HorarioLaboralProgramadoPorEmpleados)
                .Include(e => e.HoraExtras)
                .Include(e => e.TipoEventoEmpleado)
                .AsNoTracking()
                .FirstOrDefault();

            return emp;

        }

        public bool Add(Models.Entities.Domain.Empleado empleado)
        {
            try
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear empleado: " + ex.Message);
            }
        }

        public List<model.Empleado> GetAllComplete()
        {
            try
            {
                return _context.Empleados
                    .Include(x => x.Cargo)
                    .Include(x => x.Sede)
                    .Include(x => x.TipoContrato)
                    .Include(x => x.Jefe)
                        .ThenInclude(j => j.Cargo)
                    .Include(x => x.InverseJefe)
                        .ThenInclude(ij => ij.Cargo)
                    .Include(x => x.EventoEmpleadoEmpleados)
                        .ThenInclude(z => z.TipoEventoEmpleado)
                    .Include(x => x.EventoEmpleadoEmpleados)
                        .ThenInclude(q => q.AutorizadoPorEmpleado)
                    .Include(x => x.HorarioLaboralEmpleados)
                    .Include(x => x.HorarioLaboralProgramadoPorEmpleados)
                    .Include(x => x.HoraExtras)
                    .Include(x => x.TipoEventoEmpleado)
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar empleados: " + ex.Message);
            }
        }

        public List<model.Empleado> GetAll()
        {
            try
            {
                var cargosPermitidos = new List<int> { 1, 3, 4, 8 };

                return _context.Empleados
                    .AsNoTracking()
                    .Where(e => cargosPermitidos.Contains(e.CargoId))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar empleados: " + ex.Message);
            }
        }
    }
}
