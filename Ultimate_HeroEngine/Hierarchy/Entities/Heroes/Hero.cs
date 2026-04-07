using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Interfaces;
using Ultimate_HeroEngine.Hierarchy;

namespace Ultimate_HeroEngine.Entities;

public abstract class Hero : Entity, IUseAbility
{
    public List<Ability> Abilities { get; set; }
    public Hero(string name, int level, float hp, float skill, int defenseBuff, List<Ability> abilities) : base(name, level, hp, skill, defenseBuff)
    {
        Abilities = abilities;
    }

    public List<Ability> SortAbilitiesList()
    {
        Abilities.Sort();
        return Abilities;
    }

    public override string GetCategoryName() => "Hero";
    public virtual string GetAbilityCostValue() => KeyValues.DefAbilityCost;
}