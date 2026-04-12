using Ultimate_HeroEngine.Core.Objects;
using Ultimate_HeroEngine.Entities;
using Ultimate_HeroEngine.Hierarchy;
using Ultimate_HeroEngine.Hierarchy.BattleField;
using Ultimate_HeroEngine.Logic.SupportClasses;

public static class Program
{
    public static void Main()
    {
        
        MenuManager.PresentProgram();
        CombatEngine battle = new CombatEngine(new Team());
        MenuManager.CombatFlow(battle);
    }
}
