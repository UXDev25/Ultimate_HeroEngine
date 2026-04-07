using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Entities;
using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Enums;
using Ultimate_HeroEngine.Core.Interfaces;
using Ultimate_HeroEngine.Hierarchy.BattleField.AI;
using Utils;

namespace Ultimate_HeroEngine.Hierarchy.BattleField;


public class CombatEngine
{
    private Team _enemyTeam; 
    private Team _heroTeam;
    private Team _allEntities;
        
    public int Round { get; set; }

    public Team HeroTeam
    {
        get => _heroTeam;
        set
        {
            if (value.Members.All(entity => entity is not Hero)) 
                throw new ArgumentException("Hero Team only can contain Heroes");
            _heroTeam = value;
        }
    }
    
    public Team EnemyTeam
    {
        get => _enemyTeam;
        set
        {
            if (value.Members.All(entity => entity is not Enemy)) 
                throw new ArgumentException("Enemy Team only can contain Enemies");
            _enemyTeam = value;
        }
    }
    
    public CombatEngine(Team heroes, Team enemies)
    {
        HeroTeam = heroes;
        EnemyTeam = enemies;
        _allEntities = new Team();
        UpdateEntitiesList();
        Round = 1;
    }

    private void UpdateEntitiesList()
    {
        _allEntities.Members.Clear();
        _allEntities.Members.AddRange(HeroTeam.Members);
        _allEntities.Members.AddRange(EnemyTeam.Members);
    }

    public void Battle()
    {
        List<Action> actions = new List<Action>();
        UpdateEntitiesList();
        Console.WriteLine(UI.StartBattle);
        while (EnemyTeam.Members.Count != 0 || HeroTeam.Members.Count != 0)
        {
            Console.WriteLine(UI.Round, Round);
            UIManager.ListTeam(EnemyTeam.Members);
            UIManager.ListTeam(HeroTeam.Members);
            actions = GetTeamActions(HeroTeam.Members);
            actions.AddRange(EnemyAI.GetEnemyActions(EnemyTeam, HeroTeam, _allEntities));
            actions.Sort();
            ExecuteActions(actions);
            Round++;
        }

        string WinMsg = HeroTeam.Members.Count != 0 ? UI.HeroWin : UI.EnemyWin; 
        Console.WriteLine(WinMsg);
    }
    
    public List<Action> GetTeamActions(List<Entity> heroTeam)
    {
        var actionList = new List<Action>();
        int i = 0;
        
        while (i < heroTeam.Count)
        {
            Hero currentHero = (Hero)heroTeam[i];
            int actionChoiceRaw = 0;
            
            Console.WriteLine((UI.ActionList, currentHero.Name) + (i == 0 ? "" : UI.GoBackMember));
            Tools.CheckInt(ref actionChoiceRaw, KeyValues.ActionMinNumber, KeyValues.ActionMaxNumber, Messages.Error);
            Console.Clear();
            ECombatAction actionChoice = (ECombatAction)actionChoiceRaw; 
            
            if (actionChoice != ECombatAction.GoBack)
            {
                actionList[i] = ManageAction(currentHero, actionChoice);
                i++;
            }
            else if (i != 0)
            {
                actionList.Remove(actionList[i]); 
                i--;
            }
            Console.Clear();
        }
        return actionList;
    }

    private Action ManageAction(Hero hero, ECombatAction actionChoice)
    {
        ITargetable target;
        switch (actionChoice)
        {
            case ECombatAction.Attack:
                target = SelectTarget(hero, null);
                return new Action(hero, actionChoice, target);
            
            case ECombatAction.Ability:
                int chosenAbilityIndex = SelectHability(hero);
                target = SelectTarget(hero, hero.Abilities[chosenAbilityIndex]);
                return new Action(hero, actionChoice, chosenAbilityIndex, target);
            
            case ECombatAction.Introduce: return new Action(hero, actionChoice); //created for scalability, you can add more options in a future
            
            default: return new Action(hero, actionChoice);
        }
    }

    private int SelectHability(Hero hero)
    {
        int abilityChoice = 0;
        UIManager.ListAbilities(hero);
        Tools.CheckInt(ref abilityChoice, 1, hero.Abilities.Count, Messages.Error);
        return abilityChoice - 1; 
    }

    private ITargetable SelectTarget(Hero hero, Ability? chosenAbility)
    {
        ETarget currentTargetType = chosenAbility?.TargetType ?? ETarget.SingleEnemy; 
        int targetChoice = 0;

        switch (currentTargetType)
        {
            case ETarget.SingleAny:
                UIManager.ListTargets(_allEntities.Members);
                Tools.CheckInt(ref targetChoice, 1, _allEntities.Members.Count, Messages.Error);
                return _allEntities.Members[targetChoice - 1];
            
            case ETarget.SingleAlly:
                UIManager.ListTargets(HeroTeam.Members);
                Tools.CheckInt(ref targetChoice, 1, HeroTeam.Members.Count, Messages.Error);
                return HeroTeam.Members[targetChoice - 1];
            
            case ETarget.SingleEnemy:
                UIManager.ListTargets(EnemyTeam.Members);
                Tools.CheckInt(ref targetChoice, 1, EnemyTeam.Members.Count, Messages.Error);
                return EnemyTeam.Members[targetChoice - 1];
            
            case ETarget.Self:
                return hero;
            
            case ETarget.AllAllies: return HeroTeam;
            case ETarget.AllEnemies: return EnemyTeam;
            case ETarget.Everyone: return _allEntities;
            default: return null;
        }
    }

    private static void ExecuteActions(List<Action> actionList)
    {
        foreach(var entry in actionList)
        {
            Entity currentUser = entry.SelectedUser;
            switch (entry.ActionType)
            {
                case ECombatAction.Attack:
                    currentUser.AttackMeth((Entity)entry.Target);
                    break;
                case ECombatAction.Introduce:
                    Console.WriteLine(currentUser.ToString());
                    break;
                case ECombatAction.Ability:
                    IUseAbility abilityUser = (IUseAbility)currentUser;
                    abilityUser.UseAbility(entry.AbilityIndex, entry.Target);
                    break;
            }
        }
        Console.ReadKey();
    }
}