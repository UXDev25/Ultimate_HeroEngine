using Ultimate_HeroEngine.Core.Enums;
using Ultimate_HeroEngine.Entities;

namespace Ultimate_HeroEngine.Abilities;

public class Healing : Ability
{
    public Healing(string name, int cost, ERarity rarity, int power, ETarget targetType, int userSkill) : base(name, cost, rarity, power, targetType, userSkill) { }
    
    public void Heal(Entity target)
    {
        target.Hp = target.Hp >= target.MaxHp ? target.Hp : target.Hp + Power * UserSkill / 1.5f;
    }
}