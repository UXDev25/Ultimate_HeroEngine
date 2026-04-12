namespace Ultimate_HeroEngine.Core;

public class KeyValues
{
    //***General***
    public const int ActionMaxNumber = 4;
    public const int ActionMinNumber = 1;
    public const float DefPower = 40;
    public const int RandomLevelRange = 4;
    public const int DefTeamSize = 4;
    public const int BossTeamSize = 2;
    public const int MaxAbilityNum = 4;
    public const int MinDefaultDamage = 1;
    
    //***Heroes***
    public const string DefAbilityCost = "Points";
    public const string WarrAbilityCost = "Hp";
    public const string RogueAbilityCost = "Hidden daggers";
    public const string MageAbilityCost = "Mana";
    
    
    //---------------------------Level Increase
    public const float DefHpIncrease = 11.5f;
    public const float DefDefIncrease = 1.5f;
    public const float DefSkillIncrease = 2.5f;
    public const int DefArmorIncrease = 2;
    public const int DefManaIncrease = 10;
    public const int DefArkLvlIncrease = 1;
    public const int DefDaggersIncrease = 1;
    public const float DefMultIncrease = 0.01f;
    
    //--------------------------Default Ability Costs
    public const int DefFreeCost = 0;
    public const int DefCommonCost = 5;
    public const int DefRareCost = 15;
    public const int DefEpicCost = 25;
    public const int DefLegendaryCost = 40;
    
    //--------------------------Default Ability Power
    public const int DefMinPower = 0;
    public const int DefCommonPower = 20;
    public const int DefRarePower = 50;
    public const int DefEpicPower = 80;
    public const int DefLegendaryPower = 120;
    public const float DefDefense = 5;
   
    //-------Warrior
    public const float DefWarriorHp = 150;
    
    public const float DefWarriorSkill = 5;
    public const int DefWarriorArmor = 10;
    
    //-------Rogue
    public const int DefRogueHp = 80;
    public const float DefRogueSkill = 12;
    public const float DefRogueMult = 1.5f;
    public const int DefRogueDaggers = 10;
    
    //-------Mage
    public const float DefMageHp = 100;
    public const float DefMageSkill = 1;
    public const int DefMageMana = 15;
    public const int DefMageArk = 1;

    //--Introduces
    public const string DefIntroduce = "[{0}] {1} | Level: {2} | HP: {3}/{4}";
    public const string WarriorIntroduce = " Armor: {0} | Battle Cry: '{1}'";
    public const string MichaelCry = "For pain and for glory! Bytecroft will not sucumb against bugs!";
    public const string MageIntroduce = " Mana: {0} | arkLvl: {1}";
    public const string RogueIntroduce = " Damage Multiplicator: {0} | Hidden Daggers: {1}";
    
    //***Enemies***
    public const int DefBossPow = 70;
    public const int DefElitePow = 50;
    public const int DefMinionPow = 30;
    
    //----BugBoss
    public const int DefBugBossHp = 1000;
    public const int DefBugBossDefenseBuff = 5;
    public const float DefBugBossSkill = 15.0f;
    public const float DefBugBossDmgMult = 1.25f;
    public const int DefBugBossArmor = 20;
    public const int DefBugBossMana = 250;
    
    // Elite
    public const int DefEliteHp = 300;
    public const float DefEliteSkill = 12.0f;
    public const float DefEliteDefenseBuff = 3.0f;
    public const int DefEliteMana = 100;

    // Minion
    public const float DefMinionHp = 40.0f;
    public const float DefMinionSkill = 3.0f;
    public const float DefMinionDefenseBuff = 1.0f;
    
    public const string EliteIntroduce = " Mana: {0}";
    public const string BossIntroduce = " Damage Multiplicator: {0} | Mana: {1} | Armor: {2}";
}

public static class Messages
{
    //**General**
    public const string Error = "Invalid value, please try again";
    
    
    //**In game**
    public const string HeroWin = "All enemies were defeated, the HERO team wins, congratulations!";
    public const string EnemyWin = "All heroes were defeated... the ENEMY team wins... What a shame :(";
    public const string LevelUp = "[{0}] {1} has leveled up! All its stats rised;";
    public const string NoFounds = "insufficient founds to execute this ability";
    
    //-------------Actions
    public const string Attack = "[{0}] {1} Attacked the {2} {3}!";
    public const string Introduce = "{0} introduces itself:";
    public const string Recieved = "[{0}] {1} recieved {2} points of damage! (Total health: {3}/{4})";
    public const string DefeatMsg = "[{0}] {1} has been DEFEATED!";
    public const string Failed = "One action Has failed!";
    
    //------------------------------Abilities
    public const string NoAbility = "{0} has no abilities...";
    public const string CantUseAbility = "{0} tried to do an ability, but doesn't know how to do it!";
    public const string DeadAbility = "{0} tried to do an ability, but is dead...";
    public const string UseAbility = "[{0}] {1} Used the Ability: {2}!";
    public const string Heal = "{0} has recovered {1} Hp"; 
    public const string BuffDefense = "{0} has gained more Defense"; 
    //-----------------------------------------------Effects
    public const string Nothing = "Nothing Happened...";
    public const string Cheer = "'You can do it {0}! i believe in you!'";
    public const string InstaKill = "{0} was suddenly killed...";
    public const string Fact = "Life is a carrussel";
}

public static class UI
{
    //**Combat**
    //---------------General
    public const string GenDivider = "==================================================\n{0}\n--------------------------------------------------";
    public const string Divider = "==================================================";
    public const string DividerAlt = "--------------------------------------------------";
    public const string Title = "--ULTIMATE HERO ENGINE--";
    public const string Team = "You are a brave Commander from the ByteCroft Army, you have been assigned to a HERO team, enter any key when you are ready to FIGHT";
    public const string InsertKey = "--INSERT ANY KEY TO CONTINUE--";
    
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
    
    public const string LifeState = " ALIVE";
    public const string DefeatState = " DEFEATED";

    public const string Round = "--- ROUND {0}---";
    public const string TeamTitle = "{0} Team | {1} remaining";
    public const string EntityStats = "{0} [{1}] {2} | HP: {3}/{4} -> {5}";
    
    public const string ActionList = "- What will {0} do?\n1: Attack\n2: Use Ability\n3: Introduce Themself";
    public const string SelectTarget = "Select the target:";
    public const string GoBackMember = "\n4: Go back";
    
    //----------------------------------------Abilities
    public const string AbilityListTitle = "{0}'s ABILITY LOADOUT: ";
    public const string AbilityStats = "[{0}]  {1} | Type: {2} | Target: {3} | Cost: {4} {5}";
}