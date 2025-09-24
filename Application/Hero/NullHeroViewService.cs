using Hero.Shared.DTO.Hero;
using MediatR;

namespace Hero.Application.Hero;

public class NullHeroViewService(ISender sender)
    : IHeroViewService
{
    private readonly ISender _sender = sender;

    public async Task<IReadOnlyList<HeroDTO>?> GetHeroesAsync() => await Task.FromResult<IReadOnlyList<HeroDTO>?>(null);
    
    public async Task<IReadOnlyList<HeroTypeDTO>?> GetHeroTypesAsync() => await Task.FromResult<IReadOnlyList<HeroTypeDTO>?>(null);
    public async Task<HeroDTO> GetHeroAsync(int heroid) => await Task.FromResult(Result.Fail<HeroDTO>("Get Hero not implemented"));
    public async Task<HeroAttributesDTO> GetHeroAttributesAsync(int heroid) => await Task.FromResult(Result.Fail<HeroAttributesDTO>("Get Hero Attributes not implemented"));
    public async Task<Result<HeroDTO>> CreateHeroAsync(HeroDTO hero) => await Task.FromResult(Result.Fail<HeroDTO>("Create Hero not implemented"));
    public async Task<Result<HeroDTO>?> UpdateHeroAsync(HeroDTO hero) => await Task.FromResult(Result.Fail<HeroDTO>("Update Hero not implemented"));
} 