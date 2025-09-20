using Hero.Shared.DTO.Hero;

namespace Hero.Application.Hero.GetHero;

public class GetHeroQueryHandler(_Hero.IHeroRepository heroRepository)
    : IQueryHandler<GetHeroQuery, IReadOnlyList<HeroDTO>>
{
    private readonly _Hero.IHeroRepository _heroRepository = heroRepository;

    public async Task<Result<IReadOnlyList<HeroDTO>>> Handle(GetHeroQuery request, CancellationToken cancellationToken)
    {
        var heroes = await _heroRepository.GetAllHeroesAsync();
        
        return heroes.Select(h => new HeroDTO
        {
            id = h.id,
            name = h.name,
            type = h.type,
            story = h.story,
            datecreated = h.datecreated,
        }).ToList();
    }
}