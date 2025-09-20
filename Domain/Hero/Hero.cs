using Hero.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hero.Domain.Hero.Heroes;

[Table("hero")]
public class Hero : Entity
{
    public required string name {get;set;}
    public required int type {get;set;}
    public string story {get;set;} = string.Empty;
}