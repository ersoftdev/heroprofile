using Hero.Shared.DTO.Hero;

namespace Hero.Application.Hero.GetHero;
public sealed record GetHeroByIdQuery : IQuery<HeroDTO> 
{
    public int HeroId { get; set; }
}
