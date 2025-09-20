using _Hero = Hero.Domain.Hero.Heroes;
using Hero.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hero.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("local")));
        //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("local")));

        services.AddHttpContextAccessor();
        services.AddScoped<_Hero.IHeroRepository, HeroRepository>();

        return services;
    }
}
