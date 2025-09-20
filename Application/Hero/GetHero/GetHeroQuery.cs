using Hero.Shared.DTO.Hero;

namespace Hero.Application.Hero.GetHero;
public sealed record GetHeroQuery : IQuery<IReadOnlyList<HeroDTO>> { }
