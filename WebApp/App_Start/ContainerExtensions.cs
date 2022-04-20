using BD;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBL;

namespace WebApp
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {
            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IServicioService, ServicioService>();
            services.AddTransient<INacionalidadService, NacionalidadService>();
            services.AddTransient<ITipoClienteService, TipoClienteService>();

            return services;
        }
    }
}
