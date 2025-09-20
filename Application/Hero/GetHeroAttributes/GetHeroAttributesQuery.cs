using Hero.Shared.DTO.Hero;

namespace Hero.Application.Hero.GetHero;
public sealed record GetHeroAttributesQuery : IQuery<HeroAttributesDTO> 
{
    public int HeroId { get; set; }
}
