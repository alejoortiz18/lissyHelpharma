using Business.BusinessBLL;
using Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Dependences
{
    public static class BusinessAccessDependency
    {
        public static IServiceCollection BusinessDependencyInjectionAccess(this IServiceCollection services)
        {

            #region [ Repository Data Access ]

            services.AddScoped<IEmpleadoBusiness, EmpleadoBusiness>();
            services.AddScoped<IEventoBusiness, EventoBusiness>();

            //
            #endregion

            return services;
        }
    }
}