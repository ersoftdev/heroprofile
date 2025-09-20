using Hero.Shared.DTO.Hero;

namespace Hero.Application.Hero.GetHero;

public class GetHeroAttributesQueryHandler(_Hero.IHeroRepository heroRepository)
    : IQueryHandler<GetHeroAttributesQuery, HeroAttributesDTO>
{
    private readonly _Hero.IHeroRepository _heroRepository = heroRepository;

    public async Task<Result<HeroAttributesDTO>> Handle(GetHeroAttributesQuery request, CancellationToken cancellationToken)
    {
        var result =  await _heroRepository.GetHeroAttributesAsync(request.HeroId);

        return new HeroAttributesDTO
        {
            strength = result!.strength,
            vitality = result!.vitality,
            dexterity = result!.dexterity,
            wisdom = result!.wisdom,
            luck = result!.luck
        }!;
    }
}