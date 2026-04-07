using Ultimate_HeroEngine.Core.Interfaces;
using Ultimate_HeroEngine.Entities;

namespace Ultimate_HeroEngine.Hierarchy;

public class Team : ITargetable
{
    public List<Entity> Members { get; set; }

    public Team(List<Entity> members)
    {
        Members = members;
    }
    
    public Team()
    {
        Members = new List<Entity>(0);
    }
}