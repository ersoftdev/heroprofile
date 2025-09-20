using Hero.Shared.DTO.Hero;

namespace Hero.Application.Hero.GetHero;

public class GetHeroByIdQueryHandler(_Hero.IHeroRepository heroRepository)
    : IQueryHandler<GetHeroByIdQuery, HeroDTO>
{
    private readonly _Hero.IHeroRepository _heroRepository = heroRepository;

    public async Task<Result<HeroDTO>> Handle(GetHeroByIdQuery request, CancellationToken cancellationToken)
    {
        var hero = await _heroRepository.GetHeroByIdAsync(request.HeroId);
        if (hero is null)
        {
            throw new ArgumentNullException(nameof(hero));
        }
        return new HeroDTO { id = hero.id, name = hero.name, type = hero.type, story = hero.story, datecreated = hero.datecreated };
    }
}