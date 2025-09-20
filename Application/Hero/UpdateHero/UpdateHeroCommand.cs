using Hero.Shared.DTO.Hero;


namespace Hero.Application.Hero.CreateHero;

public class UpdateHeroCommand : ICommand<HeroDTO?>
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required int Type { get; set; }
    public required string Story { get; set; }
}
