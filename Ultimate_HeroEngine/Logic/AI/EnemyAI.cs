using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Enums;
using Ultimate_HeroEngine.Core.Interfaces;
using Ultimate_HeroEngine.Entities;
using Ultimate_HeroEngine.Hierarchy;
using Ultimate_HeroEngine.Logic.SupportClasses;

namespace Ultimate_HeroEngine.Logic.AI;

public static class EnemyAi
{
    public static List<CombatAction> GetEnemyActions(Team enemyTeam, Team heroTeam, Team allEntities)
    {
        var actionList = new List<CombatAction>();
        var rand = new Random();
        ITargetable? target;
        
        foreach (var enemy in enemyTeam.Members)
        {
            ECombatAction actionChoice = (ECombatAction)rand.Next(KeyValues.ActionMinNumber, KeyValues.ActionMaxNumber);
            if (enemy is IUseAbility notMinion && actionChoice == ECombatAction.Ability)
            {
                int abilityIndex = rand.Next(0, notMinion.Abilities.Count);
                target = SelectTargetEnemy((Enemy)notMinion, notMinion.Abilities[abilityIndex], enemyTeam, heroTeam, allEntities);
                actionList.Add(new CombatAction(enemy,actionChoice,abilityIndex,target));
            }
            else
            {
                if (!(enemy is IUseAbility) && actionChoice == ECombatAction.Ability) actionChoice = ECombatAction.Attack;
                
                target = SelectTargetEnemy((Enemy)enemy, null, enemyTeam, heroTeam, allEntities);
                actionList.Add(new CombatAction(enemy,actionChoice,target));
            }
        }
        return actionList;
    }
    
    private static ITargetable? SelectTargetEnemy(Enemy enemy, Ability? chosenAbility, Team enemyTeam, Team heroTeam, Team allEntities)
    {
        var rand = new Random();
        ETarget currentTargetType = chosenAbility != null ? chosenAbility.TargetType : ETarget.SingleEnemy; 
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