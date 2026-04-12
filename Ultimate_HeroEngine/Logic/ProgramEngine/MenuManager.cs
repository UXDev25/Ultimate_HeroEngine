using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Objects;
using Ultimate_HeroEngine.Entities;
using Ultimate_HeroEngine.Hierarchy;

namespace Ultimate_HeroEngine.Logic.ProgramEngine;

public static class MenuManager
{
    /// <summary>
    /// Displays the program's initial presentation, showing the title and team information, 
    /// and waits for the user to continue before clearing the console.
    /// </summary>
    public static void PresentProgram()
    {
        Console.WriteLine(UI.GenDivider, UI.Title);
        Console.WriteLine(UI.Team);
        UiManager.ContinueAsk();
        Console.Clear();
    }

    /// <summary>
    /// Manages the main combat progression loop, handling consecutive battles until a game over condition is met.
    /// It automatically initializes the hero team, generates random enemy encounters (triggering a boss fight every three rounds),
    /// resets combat stats, and fully restores the heroes' health before starting each new battle.
    /// </summary>
    /// <param name="battle">The core combat engine instance that will execute and manage the battles.</param>
    public static void CombatFlow(CombatEngine battle)
    {
        battle.HeroTeam = new Team(DefaultEntities.Heroes.Cast<Entity>().ToList());
        bool isBossFight = false;
        bool isGameOver = false;
        int i = 1;
        int auxI = 0;
        while (!isGameOver)
        {
            battle.EnemyTeam = new Team(DefaultEntities.GetRandomEnemies(isBossFight, battle.HeroTeam.Members[0].Level).Cast<Entity>().ToList());
            i++;
            isBossFight = i - auxI == 3;
            if (isBossFight) auxI = i;
            battle.RestartStats();
            battle.HeroTeam.Members.ForEach(member => member.Hp = member.MaxHp);
            isGameOver = battle.StartBattle();
        }
    }
}