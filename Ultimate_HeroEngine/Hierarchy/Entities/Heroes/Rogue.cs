using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Interfaces;

namespace Ultimate_HeroEngine.Entities;

public class Rogue : Hero
{
    public float DmgMult { get; set; }
    public int HiddenDaggers { get; set; }

    public Rogue(string name, int level, float hp, float skill, int defenseBuff, List<Ability> abilities, float dmgMult, int hiddenDaggers) : base(name, level, hp, skill, defenseBuff, abilities)
    {
        DmgMult = dmgMult;
        HiddenDaggers = hiddenDaggers;
    }
    
    public override string ToString() => base.ToString() + (KeyValues.RogueIntroduce, DmgMult, HiddenDaggers);
    
    public override void AttackMeth(Entity target)
    {
        target.RecieveDamage(Skill * KeyValues.DefPower * DmgMult);
    }
    
    public override void LevelUp()
    {
        base.LevelUp();
        DmgMult += KeyValues.DefMultIncrease;
        HiddenDaggers += KeyValues.DefDaggersIncrease;
    }
    
    public override string GetAbilityCostValue() => KeyValues.RogueAbilityCost;
}