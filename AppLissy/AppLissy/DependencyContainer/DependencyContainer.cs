using Business.Dependences;
using Data.Dependences;

namespace AppLissy.DependencyContainer
{
    public static class DependencyContainer
    {
        public static IServiceCollection DependencyInjection(this IServiceCollection services)
        {
            //services.AddScoped<IMetasLevel, MetasLevel>();
            //services.AddScoped<IUsuarioValidation, UsuarioValidation>();

            services.DataDependencyInjectionAccess();
            services.BusinessDependencyInjectionAccess();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .WithOrigins("*"));
            });

            return services;
        }
    }
}
