using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Entities;
using Ultimate_HeroEngine.Hierarchy;

namespace Ultimate_HeroEngine.Core.Interfaces;

public interface IUseAbility
{
    public List<Ability> Abilities { get; set; }

    public void UseAbility(int abilityIndex, ITargetable target)
    {
        if (target is Team team)
        {
            foreach (var member in team.Members) CastAbilityType(Abilities[abilityIndex], member);
        }
        else CastAbilityType(Abilities[abilityIndex], (Entity)target);
    }

    private void CastAbilityType(Ability ability, Entity target)
    {
        switch (ability)
        {
            case Attack attackType:
                attackType.AttackMeth(target);
                break;
            case Healing healingType:
                healingType.Heal(target);
                break;
            case Defense defenseType:
                defenseType.RaiseDefense(target);
                break;
            case Support supportType:
                supportType.ApplyEffect(target);
                break;
        }
    }
}