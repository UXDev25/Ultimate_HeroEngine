using Ultimate_HeroEngine.Abilities;

namespace Ultimate_HeroEngine.Entities;

public abstract class Enemy : Entity
{
    public Enemy(string name, int level, float hp, float skill, int defenseBuff) : base(name, level, hp, skill, defenseBuff) { }
    public override string GetCategoryName() => "Enemy";
}