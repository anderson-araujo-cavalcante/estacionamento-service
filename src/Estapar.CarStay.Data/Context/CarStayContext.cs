using Estapar.CarStay.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Estapar.CarStay.Data.Context
{
    public class CarStayContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public CarStayContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<Passage> Passages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }
    }
}
