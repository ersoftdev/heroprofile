using Hero.Shared.DTO.Hero;
using Hero.Application.Hero.GetHero;
using MediatR;
using Hero.Application.Hero.GetHeroType;
using Hero.Application.Hero.CreateHero;

namespace Hero.Application.Hero;

public class HeroViewService(ISender sender)
    : IHeroViewService
{
    private readonly ISender _sender = sender;

    public async Task<IReadOnlyList<HeroDTO>?> GetHeroesAsync() => (await _sender.Send(new GetHeroQuery())).Value;
    public async Task<IReadOnlyList<HeroTypeDTO>?> GetHeroTypesAsync() => (await _sender.Send(new GetHeroTypeQuery())).Value;
    public async Task<HeroDTO> GetHeroAsync(int heroid) => (await _sender.Send(new GetHeroByIdQuery() { HeroId = heroid })).Value;
    public async Task<HeroAttributesDTO> GetHeroAttributesAsync(int heroid) => (await _sender.Send(new GetHeroAttributesQuery() {  HeroId = heroid })).Value;
    public async Task<HeroDTO> CreateHeroAsync(HeroDTO hero) => (await _sender.Send(new CreateHeroCommand()
                                                                {
                                                                    Name = hero.name,
                                                                    Type = hero.type,
                                                                    Story = hero.story
                                                                })).Value;
    public async Task<HeroDTO?> UpdateHeroAsync(HeroDTO hero) => (await _sender.Send(new UpdateHeroCommand()
                                                                {
                                                                    Id = hero.id,
                                                                    Name = hero.name,
                                                                    Type = hero.type,
                                                                    Story = hero.story
                                                                })).Value;
} 