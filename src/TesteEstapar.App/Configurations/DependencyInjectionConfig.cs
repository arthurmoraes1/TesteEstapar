using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteEstapar.Business.Interfaces;
using TesteEstapar.Business.Notificacoes;
using TesteEstapar.Business.Services;
using TesteEstapar.Data.Context;
using TesteEstapar.Data.Repository;

namespace TesteEstapar.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<ICarroRepository, CarroRepository>();
            services.AddScoped<IManobristaRepository, ManobristaRepository>();
            services.AddScoped<IResponsavelManobraRepository, ResponsavelManobraRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ICarroService, CarroService>();
            services.AddScoped<IManobristaService, ManobristaService>();
            services.AddScoped<IResponsavelManobraService, ResponsavelManobraService>();

            return services;
        }
    }
}
