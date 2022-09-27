using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureRegistration
{
    public static void AddingDbConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ICOConnection");
        services.AddDbContext<ApplicationContext>(option => 
        option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
}
