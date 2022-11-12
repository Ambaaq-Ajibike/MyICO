using System.Reflection;
using Infrastructure.Database;
using Infrastructure.Database.Repositories;
using MediatR;
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
        services.AddScoped<IContestantRepository, ContestRepository>();
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IScoreRepository, ScoreRepository>();
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
    }
}
