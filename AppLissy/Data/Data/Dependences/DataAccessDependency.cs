using Data.Interfaces;
using Data.Repository.Cargos;
using Data.Repository.Contratos;
using Data.Repository.Empleado;
using Data.Repository.Evento;
using Data.Repository.Sedes;
using Data.Repository.Solicitudes;
using Microsoft.Extensions.DependencyInjection;
using Models.Entities.Domain;

namespace Data.Dependences
{
    public static class DataAccessDependency
    {
        public static IServiceCollection DataDependencyInjectionAccess(this IServiceCollection services)
        {

            #region [ Repository Data Access ]

            services.AddScoped<IEmpleadoRespository, EmpleadoRespository>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<ISolicitudesRepository, SolicitudesRepository>();
            services.AddScoped<ICargosRepository, CargosRepository>();
            services.AddScoped<ISedesRepository, SedesRepository>();
            services.AddScoped<IContratoRepository, ContratoRepository>();
            //
            #endregion


            #region [General]
            services.AddScoped<AppDbContext>();
            #endregion

            return services;
        }
    }
}
