using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Entities;
using Ultimate_HeroEngine.Hierarchy;
using Utils;

namespace Ultimate_HeroEngine.Core;

public static class UIManager
{
    /// <summary>
    /// Asks the user to insert a key to continue with the program thread
    /// </summary>
    public static void ContinueAsk()
    {
        Console.WriteLine(UI.InsertKey);
        Console.ReadKey();
    }
    
        /// <summary>
    /// Displays the team's header information, including its category and total number of members, 
    /// and then lists all individual members.
    /// </summary>
    /// <param name="team">The team whose header and members will be displayed.</param>
    public static void ListTeam(Team team)
    {
        string teamData = String.Format(UI.TeamTitle, team.Members[0].GetCategoryName(), team.Members.Count + team.DefeatedMembers.Count);
        Console.WriteLine(UI.GenDivider, teamData);
        ShowMembers(team);
    }

    /// <summary>
    /// Prompts the player with a target selection message and displays the list of potential targets 
    /// from the specified team.
    /// </summary>
    /// <param name="targets">The team containing the available target entities.</param>
    public static void ListTargets(Team targets)
    {
        Console.WriteLine(UI.SelectTarget);
        ShowMembers(targets);
    }

    /// <summary>
    /// Consolidates both active and defeated members of a team and displays their detailed statistics 
    /// (such as name, HP, class, and defeat status) in a numbered list format.
    /// </summary>
    /// <param name="team">The team whose members' statistics will be shown.</param>
    public static void ShowMembers(Team team)
    {
        int i = 1;
        List<Entity> allMembers = team.Members.Concat(team.DefeatedMembers).ToList();
        foreach (var entity in allMembers)
        {
            Console.WriteLine(String.Format(UI.EntityStats, i, entity.GetCategoryName(), entity.Name, entity.Hp, entity.MaxHp, entity.GetType().Name) + String.Format(entity.IsDefeated ? UI.DefeatState : ""));
            i++;
        }
    }

    /// <summary>
    /// Displays a formatted list of all available abilities for a specific hero, including their stats 
    /// and costs. If the hero currently has no abilities, a warning message is shown instead.
    /// </summary>
    /// <param name="hero">The hero whose abilities will be listed and sorted.</param>
    public static void ListAbilities(Hero hero)
    {
        Console.WriteLine(UI.GenDivider, String.Format(UI.AbilityListTitle, hero.Name));
        if (hero.Abilities.Count == 0)
        {
            Console.WriteLine(Messages.NoAbility);
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