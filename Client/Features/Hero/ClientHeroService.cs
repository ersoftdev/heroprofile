using Hero.Application.Hero;
using Hero.Domain.Abstractions;
using Hero.Shared.DTO.Hero;
using System.Net.Http.Json;

namespace Hero.Client.Features.Heroes;

public class ClientHeroService//(HttpClient http)
    : IHeroViewService
{
    private readonly HttpClient _http;// = http;
    public ClientHeroService(HttpClient http)
    {
        Console.WriteLine("ClientHeroService started");
        _http = http;
    }

    public async Task<IReadOnlyList<HeroDTO>?> GetHeroesAsync() => await _http.GetFromJsonAsync<IReadOnlyList<HeroDTO>>("/api/Hero/GetHeroes");

    public async Task<IReadOnlyList<HeroTypeDTO>?> GetHeroTypesAsync() => await _http.GetFromJsonAsync<IReadOnlyList<HeroTypeDTO>>("api/Hero/GetHeroTypes");

    public async Task<HeroDTO> GetHeroAsync(int heroid) => await _http.GetFromJsonAsync<HeroDTO>($"api/Hero/GetHeroById/{heroid}");

    public async Task<HeroAttributesDTO> GetHeroAttributesAsync(int heroid) => await _http.GetFromJsonAsync<HeroAttributesDTO>($"api/Hero/GetHeroAttributes/{heroid}");

    public async Task<Result<HeroDTO>> CreateHeroAsync(HeroDTO hero)
    {
        var response = await _http.PostAsJsonAsync<HeroDTO>("api/Hero/CreateHero", hero);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<HeroDTO>();
    }
    public async Task<Result<HeroDTO>?> UpdateHeroAsync(HeroDTO hero)
    {
        var result = await _http.PutAsJsonAsync<HeroDTO>($"api/Hero/UpdateHero/{hero.id}", hero);

        result.EnsureSuccessStatusCode();

        return await result.Content.ReadFromJsonAsync<HeroDTO>();
    }
}