namespace Ultimate_HeroEngine.Core;

public class KeyValues
{
    //***General***
    public const int ActionMaxNumber = 4;
    public const int ActionMinNumber = 1;
    
    public const int DefPower = 10;
    public const string DefAbilityCost = "Points";
    public const string WarrAbilityCost = "Hp";
    public const string RogueAbilityCost = "Hidden daggers";
    public const string MageAbilityCost = "Mana";
    
    
    //---------------------------LevelIncrease
    public const float DefHpIncrease = 11.5f;
    public const float DefDefIncrease = 1.5f;
    public const float DefSkillIncrease = 2.5f;
    public const int DefArmorIncrease = 2;
    public const int DefManaIncrease = 10;
    public const int DefArkLvlIncrease = 1;
    public const int DefDaggersIncrease = 1;
    public const float DefMultIncrease = 0.01f;
    
    //***Heroes***
    public const int DefWarriorPow = 50;
    public const int DefRoguePow = 30;
    public const int DefMagePow = 20;

    public const string DefIntroduce = "[{0}] {1} | Level: {2} | HP: {3}/{4}";
    public const string WarriorIntroduce = " Armor: {0} | Battle Cry: '{1}'";
    public const string MageIntroduce = " Mana: {0} | arkLvl: {1}";
    public const string RogueIntroduce = " Damage Multiplicator: {0} | Hidden Daggers: {1}";
    
    //***Enemies***
    public const int DefBossPow = 70;
    public const int DefElitePow = 50;
    public const int DefMinionPow = 30;
    
    
    public const string EliteIntroduce = " Mana: {0}";
    public const string BossIntroduce = " Damage Multiplicator: {0} | Mana: {1} | Armor: {2}";
}

public static class Messages
{
    public const string Error = "Invalid value, please try again";
}

public static class UI
{
    //**Combat**
    //---------------General
    public const string GenDivider = "==================================================\n{0}\n--------------------------------------------------";
    public const string Divider = "==================================================";
    public const string DividerAlt = "--------------------------------------------------";
    
    //---------------Log
    public const string Log = "BATTLE LOG - Round {0}";
    public const string EntityAction = "[{0}]  {1} > {2} > {3}";
    public const string RemainingEntities = "Remaining enemies: {0} | Heroes standing: {1}";

    public const string TotalStats = "TOTAL STATS:";
    public const string Stats = "[{0}] {1}:\n- total damage: {2}\n- kills: {3}\n- defeated on: {4}";
    public const string Result = "COMBAT RESULT:";
    public const string FinalTotal = "- Total damage made: {0}\n- Best hero: {1}\n- Fastest defeated Enemy: {2}";
    
    //---------------In Game
    public const string StartBattle = "Your team arrives to the battlefield... an enemy team appeared!\n FIGHT!\n";
    
    
    public const string LifeState = "ALIVE";
    public const string DefeatState = "DEFEATED";

    public const string Round = "--- ROUND {0}---";
    public const string TeamTitle = "{0} Team | {1} remaining";
    public const string EntityStats = "{0} [{1}] {2} | HP: {3}/{4} -> {5}";
    
    public const string ActionList = "- What will {0} do?\n1: Attack\n2: Use Ability\n3: Introduce Themself";
    public const string SelectTarget = "Select the target:";
    public const string GoBackMember = "\n4: Go back";

    public const string HeroWin = "All enemies were defeated, the HERO team wins, congratulations!";
    public const string EnemyWin = "All heroes were defeated... the ENEMY team wins... What a shame :(";
    
    //------------------------------Actions
    public const string Attack = "[{0}] {1} Attacked the {2} {3}!";
    public const string Recieved = "{0} {1} recieved {2} points of damage! (Total health: {3}/{4})";
    public const string DefeatMsg = "{0} {1} has been DEFEATED!";

    //----------------------------------------Abilities
    public const string AbilityListTitle = "{0}'s ABILITY LOADOUT: ";
    public const string NoAbility = "{0} has no abilities...";
    public const string AbilityStats = "[{0}]  {1} | Type: {2} | Target: {3} | Cost: {4} {5}";
    public const string UseAbility = "[{0}] {1} Used the Ability: {2} on ";
    public const string ToOneEntity = "{0} {1}!";
    public const string UseAbilityToAllTeam = "All the {0} Team!";
    public const string UseAbilityToAll = "All Enemies and Heroes!";

    public const string Heal = "{0} has recovered {1} Hp"; 
    
    public const string BuffDefense = "{0} has gained more Defense"; 
    
    //----------------------------------------------------Effects
    public const string Sleep = "{0} is sleeping!";
    public const string Confuse = "{0} is confused!";
}