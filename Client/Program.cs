using Hero.Application.Hero;
using Hero.Client.Features.Heroes;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//DI
builder.Services.AddScoped<IHeroViewService, ClientHeroService>();

Console.WriteLine("IHERO 1:" + typeof(IHeroViewService).Assembly.FullName);
Console.WriteLine("IHERO 2:" + typeof(ClientHeroService).Assembly.FullName);

await builder.Build().RunAsync();