using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Interfaces;
using Ultimate_HeroEngine.Hierarchy;

namespace Ultimate_HeroEngine.Entities;

public class BugBoss : Enemy, IUseAbility
{
    public List<Ability> Abilities { get; set; }
    public float DmgMult { get; set; }
    public int Armor { get; set; }
    public int Mana { get; set; }

    public BugBoss(string name, int level, int hp, float skill, int defenseBuff, List<Ability> abilities, float dmgMult, int armor, int mana) : base(name, level, hp, skill, defenseBuff)
    {
        Armor = armor;
        DmgMult = dmgMult;
        Mana = mana;
        Abilities = abilities;
    }
    
    public override string ToString() => base.ToString() + (KeyValues.BossIntroduce, DmgMult, Mana, Armor);
    
    public override void RecieveDamage(float damage)
    {
        Hp -= (1 + (DefenseBuff / 10)) - (DefenseBuff / 10) * (Armor/100);
    }

    public override void AttackMeth(Entity target)
    {
        target.RecieveDamage(Skill * KeyValues.DefPower * DmgMult);
    }
    
    public override void LevelUp()
    {
        base.LevelUp();
        Mana += KeyValues.DefManaIncrease;
        Armor += KeyValues.DefArmorIncrease;
        DmgMult += KeyValues.DefMultIncrease;
    }
    
}