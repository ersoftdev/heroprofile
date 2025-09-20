using Hero.Domain.Hero.Heroes;
using Hero.Shared.DTO.Hero;


namespace Hero.Application.Hero.CreateHero;

public class UpdateHeroCommandHandler(IHeroRepository heroRepository) : ICommandHandler<UpdateHeroCommand, HeroDTO?>
{
    private readonly IHeroRepository _heroRepository = heroRepository;
    public async Task<Result<HeroDTO?>> Handle(UpdateHeroCommand command, CancellationToken token)
    {
        var updateHero = new _Hero.Hero 
        { 
            id = command.Id,
            name = command.Name,
            type = command.Type,
            story = command.Story,
            datecreated = DateTime.Now
        };
        var result = await _heroRepository.UpdateHeroAsync(updateHero);
        if (result is null)
        {
            return Result.Fail<HeroDTO?>("No such Hero profile!");
        }
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
