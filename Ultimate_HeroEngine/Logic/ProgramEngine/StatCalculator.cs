using Ultimate_HeroEngine.Entities;

namespace Ultimate_HeroEngine.Hierarchy;

public static class StatCalculator
{
    public static float AllCombatDamage { get; set; }
    public static float LastDamagePoint { get; set; }
    public static Enemy? FastestDefeatedEnemy { get; set; }

    /// <summary>
    /// Calculates the most efective hero based on who has more kills on the team
    /// </summary>
    /// <param name="heroes">the hero team</param>
    /// <returns>the hero who made more kills</returns>
    /// <exception cref="ArgumentException">Team has to be made of heroes to calculate the effectivenes</exception>
    public static Hero CalculateEffectiveHero(Team heroes)
    {
        List<Hero> sortedHeroes = new List<Hero>();
        foreach (var member in heroes.Members)
        {
            if (member is not Hero) throw new ArgumentException("Team has to be made of heroes to calculate the effectivenes");
            sortedHeroes.Add((Hero)member);
        }
        sortedHeroes.Sort();
        return sortedHeroes.Last();
    }
}