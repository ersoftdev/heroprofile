using Hero.Domain.Hero.Heroes;
using Hero.Shared.DTO.Hero;


namespace Hero.Application.Hero.CreateHero;

public class CreateHeroCommandHandler(IHeroRepository heroRepository) : ICommandHandler<CreateHeroCommand, HeroDTO>
{
    private readonly IHeroRepository _heroRepository = heroRepository;
    public async Task<Result<HeroDTO>> Handle(CreateHeroCommand command, CancellationToken token)
    {
        var newHero = new _Hero.Hero 
        { 
            name = command.Name,
            type = command.Type,
            story = command.Story
        };
        var result = await _heroRepository.CreateHeroAsync(newHero);
        return new HeroDTO 
        { 
            id = result.id, 
            name = result.name, 
            type = result.type, 
            story = result.story, 
            datecreated = result.datecreated 
        };
    }
}
