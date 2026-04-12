using Ultimate_HeroEngine.Core.Interfaces;
using Ultimate_HeroEngine.Entities;

namespace Ultimate_HeroEngine.Hierarchy;

public class Team : ITargetable
{
    public List<Entity> Members { get; set; }

    public List<Entity> DefeatedMembers { get; set; }

    public Team(List<Entity> members)
    {
        Members = members;
        DefeatedMembers = new List<Entity>();
    }
    
    public Team()
    {
        Members = new List<Entity>(0);
        DefeatedMembers = new List<Entity>();
    }

    /// <summary>
    /// Scans the active members list and moves all defeated entities to the defeated members list.
    /// It first appends any defeated members to the tracking list and then removes them from the active roster.
    /// </summary>
    public void CleanDefeatedMembers()
    {
        DefeatedMembers.AddRange(Members.Where(member => member.IsDefeated));
        Members.RemoveAll(member => member.IsDefeated);
    }
}