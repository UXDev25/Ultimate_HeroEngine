using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Enums;
using Ultimate_HeroEngine.Entities;

namespace Ultimate_HeroEngine.Hierarchy.Abilities;

public class Support : Ability
{
    public EEffect Effect { get; set; }

    public Support(string name, int cost, ERarity rarity, int power, ETarget targetType, Entity? user, EEffect effect, EClasses classType) : base(name, cost, rarity, power, targetType, user, classType)
    {
        Effect = effect;
    }

    public override void Execute(Entity? target)
    {
        switch (Effect)
        {
            case EEffect.Cheer: 
                Console.WriteLine(Messages.Cheer, target!.Name);
                break;
            case EEffect.InstaKill:
                Console.WriteLine(Messages.InstaKill, target!.Name);
                target.Hp = 0;
                break;
            case EEffect.TellFacts:
                Console.WriteLine(Messages.Fact);
                break;
            default: 
                Console.WriteLine(Messages.Nothing);
                break;
        }
    }
}