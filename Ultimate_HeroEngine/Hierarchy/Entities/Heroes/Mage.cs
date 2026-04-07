using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core;

namespace Ultimate_HeroEngine.Entities;

public class Mage : Hero
{
    public int Mana { get; set; }
    public int ArkLvl { get; set; }

    public Mage(string name, int level, float hp, float skill, int defenseBuff , List<Ability> abilities , int mana, int arkLvl) : base(name, level, hp, skill, defenseBuff, abilities)
    {
        Mana = mana;
        ArkLvl = arkLvl;
    }
    
    public override string ToString() => base.ToString() + (KeyValues.MageIntroduce, Mana, ArkLvl);

    public override void AttackMeth(Entity target)
    {
        target.Hp = target.Hp - (((((Level * 2) / 5) + 2) * KeyValues.DefMagePow * (Skill/2)) / 50 + 2);
    }
    
    public override void LevelUp()
    {
        base.LevelUp();
        Mana += KeyValues.DefManaIncrease;
        ArkLvl += KeyValues.DefArkLvlIncrease;
    }
    
    public override string GetAbilityCostValue() => KeyValues.MageAbilityCost;
}