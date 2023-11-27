using AutoMapper;
using Estapar.CarStay.Domain.Profiles;

namespace Estapar.CarStay.API.Configuration
{
    public static class AutomapperConfig
    {
        public static IServiceCollection MapperConfig(this IServiceCollection services)
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GarageProfile>();
                cfg.AddProfile<PassageProfile>();
                cfg.AddProfile<PaymentMethodProfile>();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            return services;
        }
    }
}
