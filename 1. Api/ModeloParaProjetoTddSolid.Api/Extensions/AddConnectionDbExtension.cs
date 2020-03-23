using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestFast.Data.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestFast.Api.Extensions
{
    public static class AddConnectionDbExtension
    {
        public static void AddConnectionDbService(this IServiceCollection services, IConfiguration configuration )
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
