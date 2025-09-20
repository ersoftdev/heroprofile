namespace Hero.Domain.Hero.Heroes;

public interface IHeroRepository
{
    Task<IReadOnlyList<Hero>> GetAllHeroesAsync();
    Task<IReadOnlyList<Herotype>?> GetHeroTypesAsync();
    Task<Hero?> GetHeroByIdAsync(int heroid);
    Task<Heroattributes?> GetHeroAttributesAsync(int heroid);
    Task<Hero> CreateHeroAsync(Hero hero);
    Task<Hero?> UpdateHeroAsync(Hero hero);
}