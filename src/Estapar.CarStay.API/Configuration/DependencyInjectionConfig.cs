using Estapar.CarStay.Data.Context;
using Estapar.CarStay.Data.Repositories.Concrets;
using Estapar.CarStay.Data.Repositories.Interfaces;
using Estapar.CarStay.Domain.Concrets;
using Estapar.CarStay.Domain.Interfaces;

namespace Estapar.CarStay.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<CarStayContext>();

            services.AddScoped<IPassageService, PassageService>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<IGarageService, GarageService>();

            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IPassageRepository, PassageRepository>();
            services.AddScoped<IGarageRepository, GarageRepository>();

            return services;
        }
    }
}
