
using Application.Factories;
using Application.Factories.Interfaces;
using Application.Services;
using Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPropertyListingService, PropertyListingService>();

            services.AddScoped<IPropertyListingFactory, PropertyListingFactory>();

            return services;
        }
    }
}
