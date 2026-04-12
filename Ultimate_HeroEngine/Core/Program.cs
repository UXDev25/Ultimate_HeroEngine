using Ultimate_HeroEngine.Logic.ProgramEngine;

namespace Ultimate_HeroEngine.Core;

public static class Program
{
    public static void Main()
    {
        
        MenuManager.PresentProgram();
        CombatEngine battle = new CombatEngine();
        MenuManager.CombatFlow(battle);
    }
}