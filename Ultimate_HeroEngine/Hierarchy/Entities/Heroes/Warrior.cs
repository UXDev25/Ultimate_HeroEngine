using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core;

namespace Ultimate_HeroEngine.Entities;

public class Warrior : Hero
{
    public int Armor { get; set; }
    public string BattleCry { get; set; }

    public Warrior(string name, int level, float hp, float skill, int defenseBuff, List<Ability> abilities, int armor, string battleCry) : base(name, level, hp, skill, defenseBuff, abilities)
    {
        Armor = armor;
        BattleCry = battleCry;
    }
    
    public override string ToString()
    {
        return base.ToString() + (KeyValues.WarriorIntroduce, Armor, BattleCry);
    }

    public override void RecieveDamage(float damage)
    {
        Hp -= damage - (1 + (DefenseBuff / 10)) - (DefenseBuff / 10) * (Armor/100);
    }
    
    public override void LevelUp()
    {
        base.LevelUp();
        Armor += KeyValues.DefArmorIncrease;
    }
}