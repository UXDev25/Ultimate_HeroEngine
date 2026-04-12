using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Interfaces;
using Ultimate_HeroEngine.Core.Objects;
using Ultimate_HeroEngine.Hierarchy;

namespace Ultimate_HeroEngine.Entities;

public class Elite : Enemy, IUseAbility
{
    public List<Ability> Abilities { get; set; }
    public int Mana { get; set; }
    public int CostStat 
    { 
        get => Mana;
        set
        {
            Mana = value;
        }
    }

    public Elite(string name, int level, int hp, float skill, float defenseBuff, List<Ability> abilities, int mana) : base(name, level, hp, skill, defenseBuff)
    {
        Abilities = Abilities = AbilityCatalog.GetRandomAbilities(this);
        Mana = mana;
    }
    
    public override string ToString() => base.ToString() + String.Format(KeyValues.EliteIntroduce, Mana);
    
    
    //**Abilities
    public void UseAbility(int abilityIndex, ITargetable target)
    {
        if (target is Entity ent) Console.WriteLine(Messages.UseAbility, ent.GetType().Name, Name, Abilities[abilityIndex].Name);
        if (target is Team team)
        {
            Console.WriteLine(Messages.UseAbility, team.Members.GetType().Name, Name, Abilities[abilityIndex].Name);
            foreach (var member in team.Members)
            {
                Abilities[abilityIndex].Execute(member);
            }
        }
        else Abilities[abilityIndex].Execute((Entity)target);
    }
    
    public void AssignAbilitiesToUser()
    {
        Abilities.ForEach(ability => ability.User = this);
    }
    
    public override void LevelUp()
    {
        base.LevelUp();
        Mana += KeyValues.DefManaIncrease;
    }
}