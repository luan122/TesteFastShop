using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFast.Api.Extensions
{
    public static class AddSwaggerExtension
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Modelo de Projeto",
                    Description = "Modelo para inicio de projeto em TDD",
                    Contact = new OpenApiContact() { Name = "Luan Santos", Email = "luan__122@hotmail.com" }
                });
            });
        }
        public static void AddSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
