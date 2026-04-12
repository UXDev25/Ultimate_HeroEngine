using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core;

namespace Ultimate_HeroEngine.Entities;

public class Mage : Hero
{
    public int Mana { get; set; }
    public int ArkLvl { get; set; }
    public override int CostStat 
    { 
        get => Mana;
        set
        {
            Mana = value;
        }
    }

    public Mage(string name, int level, float hp, float skill, float defenseBuff , List<Ability> abilities , int mana, int arkLvl) : base(name, level, hp, skill, defenseBuff, abilities)
    {
        Mana = mana;
        ArkLvl = arkLvl;
    }
    
    public override string ToString() => base.ToString() + String.Format(KeyValues.MageIntroduce, Mana, ArkLvl);
    
    public override void LevelUp()
    {
        Console.WriteLine(Messages.LevelUp, GetType().Name, Name);
        base.LevelUp();
        Mana += KeyValues.DefManaIncrease;
        ArkLvl += KeyValues.DefArkLvlIncrease;
    }
    
    public override string GetAbilityCostValue() => KeyValues.MageAbilityCost;
}