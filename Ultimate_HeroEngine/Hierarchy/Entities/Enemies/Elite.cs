using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Interfaces;
using Ultimate_HeroEngine.Hierarchy;

namespace Ultimate_HeroEngine.Entities;

public class Elite : Enemy, IUseAbility
{
    public List<Ability> Abilities { get; set; }
    public int Mana { get; set; }

    public Elite(string name, int level, int hp, float skill, int defenseBuff, List<Ability> abilities, int mana) : base(name, level, hp, skill, defenseBuff)
    {
        Abilities = abilities;
        Mana = mana;
    }
    
    public override string ToString() => base.ToString() + (KeyValues.EliteIntroduce, Mana);
    
    public override void RecieveDamage(float damage)
    {
    }

    public void Attack(Entity target)
    {
        target.Hp = target.Hp - (((((Level * 2) / 5) + 2) * KeyValues.DefElitePow * (Skill/2)) / 50 + 2);
    }
    
    public override void LevelUp()
    {
        base.LevelUp();
        Mana += KeyValues.DefManaIncrease;
    }
}