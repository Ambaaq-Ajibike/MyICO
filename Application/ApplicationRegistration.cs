using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationRegistration
{
          public static IServiceCollection AddApplication(this IServiceCollection  services)
          {                   
                    services.AddMediatR(Assembly.GetExecutingAssembly());
                    return services;
          }
}
