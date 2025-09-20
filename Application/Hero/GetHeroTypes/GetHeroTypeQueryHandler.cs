using Hero.Shared.DTO.Hero;

namespace Hero.Application.Hero.GetHeroType;

public class GetHeroTypeQueryHandler(_Hero.IHeroRepository heroRepository)
    : IQueryHandler<GetHeroTypeQuery, IReadOnlyList<HeroTypeDTO>>
{
    private readonly _Hero.IHeroRepository _heroRepository = heroRepository;

    public async Task<Result<IReadOnlyList<HeroTypeDTO>>> Handle(GetHeroTypeQuery request, CancellationToken cancellationToken)
    {
        var types = await _heroRepository.GetHeroTypesAsync();
        
        return types.Select(h => new HeroTypeDTO
        {
            id = h.id,
            name = h.name
        }).ToList();
    }
}