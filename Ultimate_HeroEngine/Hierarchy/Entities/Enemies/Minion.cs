using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core;

namespace Ultimate_HeroEngine.Entities;

public class Minion : Enemy
{
    public Minion(string name, int level, float hp, float skill, float defenseBuff) : base(name, level, hp, skill, defenseBuff) { }
}