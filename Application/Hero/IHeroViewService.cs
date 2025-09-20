using Hero.Shared.DTO.Hero;

namespace Hero.Application.Hero;

public interface IHeroViewService
{
    Task<IReadOnlyList<HeroDTO>?> GetHeroesAsync();
    Task<IReadOnlyList<HeroTypeDTO>?> GetHeroTypesAsync();
    Task<HeroDTO> GetHeroAsync(int heroid);
    Task<HeroAttributesDTO> GetHeroAttributesAsync(int heroid);
    Task<HeroDTO> CreateHeroAsync(HeroDTO hero);
    Task<HeroDTO?> UpdateHeroAsync(HeroDTO hero);
}