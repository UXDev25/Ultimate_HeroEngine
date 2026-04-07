using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Enums;
using Ultimate_HeroEngine.Core.Interfaces;
using Ultimate_HeroEngine.Entities;

namespace Ultimate_HeroEngine.Abilities;

public class Attack : Ability, IAttack
{
    public Attack(string name, int cost, ERarity rarity, int power, ETarget targetType, int userSkill) : base(name, cost, rarity, power, targetType, userSkill) { }
    
    public void AttackMeth(Entity target)
    {
        target.RecieveDamage(UserSkill * KeyValues.DefPower);
    }
}