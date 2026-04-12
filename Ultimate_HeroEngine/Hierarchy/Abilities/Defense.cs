using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Enums;
using Ultimate_HeroEngine.Entities;

namespace Ultimate_HeroEngine.Hierarchy.Abilities;

public class Defense : Ability
{
    public Defense(string name, int cost, ERarity rarity, int power, ETarget targetType, Entity? user, EClasses classType) : base(name, cost, rarity, power, targetType, user, classType) { }

    public override void Execute(Entity? target)
    {
        Console.WriteLine(Messages.BuffDefense, User!.Name);
        target!.DefenseBuff += Power * User.Skill / 1.5f;
    }
}