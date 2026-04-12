using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Enums;
using Ultimate_HeroEngine.Core.Interfaces;
using Ultimate_HeroEngine.Entities;

namespace Ultimate_HeroEngine.Abilities;

public class Attack : Ability, IAttack
{
    public Attack(string name, int cost, ERarity rarity, int power, ETarget targetType, Entity user, EClasses classType) : base(name, cost, rarity, power, targetType, user,classType) { }
    
    public void AttackMeth(Entity target)
    {
        Console.WriteLine(Messages.Attack,User.GetType().Name, User.Name, target.GetType().Name, target.Name);
        target.ReceiveDamage(User.Skill * KeyValues.DefPower);
    }

    public override void Execute(Entity target)
    {
        AttackMeth(target);
    }
}