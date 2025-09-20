using Hero.Shared.DTO.Hero;

namespace Hero.Application.Hero.GetHeroType;
public sealed record GetHeroTypeQuery : IQuery<IReadOnlyList<HeroTypeDTO>> { }
