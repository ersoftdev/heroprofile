using Hero.Application.Hero;
using Microsoft.Extensions.DependencyInjection;

namespace Hero.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(conf =>
        {
            conf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });
        services.AddScoped<IHeroViewService, NullHeroViewService>();

        return services;
    }
}
