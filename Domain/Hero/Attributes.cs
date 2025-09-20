using System.ComponentModel.DataAnnotations.Schema;

namespace Hero.Domain.Hero.Heroes;

[Table("heroattributes")]
public class Heroattributes 
{
    public required int strength { get; set; }
    public required int vitality { get; set; }
    public required int dexterity { get; set; }
    public required int wisdom { get; set; }
    public required int luck { get; set; }
    public required int heroid { get; set; }    
}