
using BuberDinner.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                // Register all the handlers from the current assembly
                config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

                // Register the ValidationBehavior
                config.AddBehavior(typeof(ValidationBehavior<,>));
            });

            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}