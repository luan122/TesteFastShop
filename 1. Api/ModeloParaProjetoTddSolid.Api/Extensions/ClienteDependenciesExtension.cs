using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFast.Application.Clientes.Interfaces;
using TestFast.Application.Clientes.Services;
using TestFast.Domain.Clientes.Interfaces;
using TestFast.Domain.Clientes.Services;

namespace TestFast.Api.Extensions
{
    public static class ClienteDependenciesExtension
    {
        public static IServiceCollection AddClienteDependencies(this IServiceCollection services)
        {
            //Domain
            services.AddScoped<IClienteDomainService, ClienteDomainService>();

            //Application
            return services.AddScoped<IClienteApplicationService, ClienteApplicationService>();
        }
    }
}
