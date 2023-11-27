using Estapar.CarStay.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace Estapar.CarStay.API.Configuration
{
    public static class ConnectionConfig
    {
        public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
        {
            //var connectionString = builder.Configuration.GetConnectionString("WebApiDatabase");
            //builder.Services.AddDbContext<CarStayContext>(
            //options => options.UseSqlServer(connectionString));


            //options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));

            return builder;
        }
    }
}
