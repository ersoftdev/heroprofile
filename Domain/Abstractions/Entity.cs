namespace Hero.Domain.Abstractions;
public abstract class Entity
{
    public int id { get; set; }
    public DateTime datecreated { get; set; } = DateTime.Now;
}