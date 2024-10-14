using BuberDinner.Api.Filters;
using BuberDinner.Api.Mapping;

namespace BuberDinner.Api
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Add all services for the presentation layer
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <returns></returns>
        public static IServiceCollection AddPresenation(this IServiceCollection services)
        {
            // Add services
            services.AddEndpointsApiExplorer();

            // Add swagger, if the environment is development the swagger will be available.
            services.AddSwaggerGen();

            // Add controllers
            services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

            // Add mapping
            services.AddMapping();

            return services;
        }
    }
}
