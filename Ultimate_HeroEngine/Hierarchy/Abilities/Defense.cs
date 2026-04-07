using Ultimate_HeroEngine.Core.Enums;
using Ultimate_HeroEngine.Entities;

namespace Ultimate_HeroEngine.Abilities;

public class Defense : Ability
{
    public Defense(string name, int cost, ERarity rarity, int power, ETarget targetType, int userSkill) : base(name, cost, rarity, power, targetType, userSkill) { }

    public void RaiseDefense(Entity target)
    {
        target.DefenseBuff += Power * UserSkill / 1.5f;
    }
}