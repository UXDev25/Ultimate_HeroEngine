using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Enums;
using Ultimate_HeroEngine.Core.Interfaces;
using Ultimate_HeroEngine.Entities;

namespace Ultimate_HeroEngine.Hierarchy.BattleField.AI;

public static class EnemyAI
{
    public static List<Action> GetEnemyActions(Team enemyTeam, Team heroTeam, Team allEntities)
    {
        var actionList = new List<Action>();
        var rand = new Random();
        ITargetable target;
        
        foreach (var enemy in enemyTeam.Members)
        {
            ECombatAction actionChoice = (ECombatAction)rand.Next(KeyValues.ActionMinNumber, KeyValues.ActionMaxNumber);
            if (enemy is IUseAbility notMinion)
            {
                int abilityIndex = rand.Next(0, notMinion.Abilities.Count - 1);
                target = SelectTargetEnemy((Enemy)notMinion, notMinion.Abilities[abilityIndex], enemyTeam, heroTeam, allEntities);
                actionList.Add(new Action(enemy,actionChoice,abilityIndex,target));
            }
            else
            {
                target = SelectTargetEnemy((Enemy)enemy, null, enemyTeam, heroTeam, allEntities);
                actionList.Add(new Action(enemy,actionChoice,target));
            }
        }
        return actionList;
    }
    
    private static ITargetable SelectTargetEnemy(Enemy enemy, Ability? chosenAbility, Team enemyTeam, Team heroTeam, Team allEntities)
    {
        var rand = new Random();
        ETarget currentTargetType = chosenAbility?.TargetType ?? ETarget.SingleEnemy; 
        switch (currentTargetType)
        {
            case ETarget.SingleAny: return allEntities.Members[rand.Next(0, allEntities.Members.Count)];
            case ETarget.SingleAlly: return enemyTeam.Members[rand.Next(0, enemyTeam.Members.Count)];
            case ETarget.SingleEnemy: return heroTeam.Members[rand.Next(0, heroTeam.Members.Count)];
            case ETarget.Self: return enemy;
            case ETarget.AllAllies: return enemyTeam;
            case ETarget.AllEnemies: return heroTeam;
            case ETarget.Everyone: return allEntities;
            default: return null;
        }
    }
}