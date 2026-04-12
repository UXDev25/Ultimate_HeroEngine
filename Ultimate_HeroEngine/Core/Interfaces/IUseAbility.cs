using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Entities;
using Ultimate_HeroEngine.Hierarchy;

namespace Ultimate_HeroEngine.Core.Interfaces;

public interface IUseAbility
{
    public List<Ability> Abilities { get; set; }
    public int CostStat { get; set; }

    public void UseAbility(int abilityIndex, ITargetable? target)
    {
        if (target is Team team)
        {
            foreach (var member in team.Members) Abilities[abilityIndex].Execute(member);
        }
        else Abilities[abilityIndex].Execute((Entity)target!);
    }

    public void AssignAbilitiesToUser();
}