using Ultimate_HeroEngine.Core.Enums;
using Ultimate_HeroEngine.Core.Interfaces;
using Ultimate_HeroEngine.Entities;

namespace Ultimate_HeroEngine.Hierarchy.BattleField;

public class Action : IComparable<Action>
{
    public Entity SelectedUser { get; set; }
    public ECombatAction ActionType { get; set; }
    public int AbilityIndex { get; set; }
    public ITargetable Target { get; set; }

    public Action(Entity selectedUser, ECombatAction actionType, int abilityIndex, ITargetable target) //To act with an hability
    {
        SelectedUser = selectedUser;
        ActionType = actionType;
        AbilityIndex = abilityIndex;
        Target = target;
    }
    
    public Action(Entity selectedUser, ECombatAction actionType, ITargetable target) //To act without an hability
    {
        SelectedUser = selectedUser;
        ActionType = actionType;
        Target = target;
    }
    
    public Action(Entity selectedUser, ECombatAction actionType) //To act in general
    {
        SelectedUser = selectedUser;
        ActionType = actionType;
    }
    
    //***IComparable***
    public int CompareTo(Action? other)
    {
        if (other == null) return 1; 
        return SelectedUser.Level.CompareTo(other.SelectedUser.Level);
    }
}