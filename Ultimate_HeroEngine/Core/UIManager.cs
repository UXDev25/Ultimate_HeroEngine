using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Entities;
using Ultimate_HeroEngine.Hierarchy;
using Utils;

namespace Ultimate_HeroEngine.Core;

public static class UIManager
{
    public static void ListTeam(List<Entity> team)
    {
        Console.WriteLine(UI.GenDivider, (UI.TeamTitle, team.GetType().Name, team.Count));
        ShowMembers(team);
    }
    
    public static void ListTargets(List<Entity> targets)
    {
        Console.WriteLine(UI.SelectTarget);
        ShowMembers(targets);
    }

    
    public static void ShowMembers(List<Entity> team)
    {
        int i = 1;
        foreach (var entity in team)
        {
            Console.WriteLine(UI.EntityStats, i, entity.GetCategoryName(), entity.Name, entity.Hp, entity.MaxHp, entity.GetType().Name);
            i++;
        }
    }

    public static void ListAbilities(Hero hero)
    {
        Console.WriteLine(UI.GenDivider, (UI.AbilityListTitle, hero.Name));
        if (hero.Abilities.Count == 0)
        {
            Console.WriteLine(UI.NoAbility);
            Console.WriteLine(UI.Divider);
            return;
        }
        foreach (var ability in hero.SortAbilitiesList())
        {
            Console.WriteLine(UI.AbilityStats, ability.Rarity, ability.Name, ability.GetType().Name, ability.TargetType, ability.Cost, hero.GetAbilityCostValue());
        }
        Console.WriteLine(UI.Divider);
    }
}