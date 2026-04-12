using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Interfaces;

namespace Ultimate_HeroEngine.Entities;

public class Rogue : Hero
{
    public float DmgMult { get; set; }
    public int HiddenDaggers { get; set; }
    public override int CostStat 
    { 
        get => HiddenDaggers; set
        {
            HiddenDaggers = value;
        } 
    }

    public Rogue(string name, int level, float hp, float skill, float defenseBuff, List<Ability> abilities, float dmgMult, int hiddenDaggers) : base(name, level, hp, skill, defenseBuff, abilities)
    {
        DmgMult = dmgMult;
        HiddenDaggers = hiddenDaggers;
    }
    
    public override string ToString() => base.ToString() + String.Format(KeyValues.RogueIntroduce, DmgMult, HiddenDaggers);
    
    public override void AttackMeth(Entity target)
    {
        Console.WriteLine(Messages.Attack, GetType().Name.ToUpper(), Name, target.GetType().Name, target.Name);
        target.ReceiveDamage(Skill * KeyValues.DefPower * DmgMult);
    }
    
    public override void LevelUp()
    {
        Console.WriteLine(Messages.LevelUp, GetType().Name, Name);
        base.LevelUp();
        DmgMult += KeyValues.DefMultIncrease;
        HiddenDaggers += KeyValues.DefDaggersIncrease;
    }
    
    public override string GetAbilityCostValue() => KeyValues.RogueAbilityCost;
}