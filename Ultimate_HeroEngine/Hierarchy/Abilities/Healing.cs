using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Enums;
using Ultimate_HeroEngine.Entities;

namespace Ultimate_HeroEngine.Abilities;

public class Healing : Ability
{
    public Healing(string name, int cost, ERarity rarity, int power, ETarget targetType, Entity user, EClasses classType) : base(name, cost, rarity, power, targetType, user, classType) { }
    
    public override void Execute (Entity target)
    {
        
        float finalHp = target.Hp >= target.MaxHp ? target.Hp : target.Hp + Power * User.Skill / 1.5f;
        Console.WriteLine(Messages.Heal, target.Name, finalHp - target.Hp);
        target.Hp = finalHp;
    }
}