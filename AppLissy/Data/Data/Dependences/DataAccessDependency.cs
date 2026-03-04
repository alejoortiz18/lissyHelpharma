using Data.Interfaces;
using Data.Repository.Empleado;
using Microsoft.Extensions.DependencyInjection;
using Models.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dependences
{
    public static class DataAccessDependency
    {
        public static IServiceCollection DataDependencyInjectionAccess(this IServiceCollection services)
        {

            #region [ Repository Data Access ]

            services.AddScoped<IEmpleadoRespository, EmpleadoRespository>();
            //
            #endregion


            #region [General]
            services.AddScoped<AppDbContext>();
            #endregion

            return services;
        }
    }
}
