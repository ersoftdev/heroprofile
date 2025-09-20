namespace Hero.Shared.DTO.Hero;

public record struct HeroDTO
    (
        int id,
        string name,
        int type,
        string story,
        DateTime datecreated
    )
{}