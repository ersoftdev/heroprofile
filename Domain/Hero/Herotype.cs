using System.ComponentModel.DataAnnotations.Schema;

namespace Hero.Domain.Hero.Heroes;

[Table("herotype")]
public class Herotype 
{
    public required int id { get; set; }
    public required string name { get; set; }    
}