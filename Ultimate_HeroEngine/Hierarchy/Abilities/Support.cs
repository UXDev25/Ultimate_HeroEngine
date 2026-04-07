using Ultimate_HeroEngine.Core.Enums;
using Ultimate_HeroEngine.Entities;

namespace Ultimate_HeroEngine.Abilities;

public class Support : Ability
{
    public EEffect Effect { get; set; }

    public Support(string name, int cost, ERarity rarity, int power, ETarget targetType, int userSkill, EEffect effect) : base(name, cost, rarity, power, targetType, userSkill)
    {
        Effect = effect;
    }

    public void ApplyEffect(Entity target)
    {
        
    }
}