using Estapar.CarStay.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Estapar.CarStay.API.Configuration
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<CarStayContext>().Database.Migrate();
            }
        }
    }
}
