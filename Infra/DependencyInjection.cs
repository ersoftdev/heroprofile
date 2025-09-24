using _Hero = Hero.Domain.Hero.Heroes;
using Hero.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Hero.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<ApplicationDbContext>(options =>
        {
            //options.LogTo(Console.WriteLine, LogLevel.Information);
            options.UseNpgsql(configuration.GetConnectionString("postgre"), o => o.CommandTimeout(180));
            options.LogTo(Console.WriteLine,
                  new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuted },
                  LogLevel.Information);
        });
        //services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("postgre")));
        //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("local")));

        services.AddHttpContextAccessor();
        services.AddScoped<_Hero.IHeroRepository, HeroRepository>();

        return services;
    }
}
