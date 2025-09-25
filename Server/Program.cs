using Hero.Application;
using Hero.Infra;
using Hero.Shared.ViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Server;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
//.AddInteractiveWebAssemblyComponents()

//DI
builder.Services.AddApplication();
builder.Services.AddInfra(builder.Configuration);
builder.Services.AddMemoryCache();

builder.Services.AddSingleton(
    builder.Configuration.GetSection("AppEnv").Get<AppEnv>()!
);

builder.Services.AddControllers();

Console.WriteLine($"ASP.NET Core Environment: {builder.Environment.EnvironmentName}");

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Client.Features.Hero.Components.Heroes).Assembly);

app.MapControllers();

await app.RunAsync();   