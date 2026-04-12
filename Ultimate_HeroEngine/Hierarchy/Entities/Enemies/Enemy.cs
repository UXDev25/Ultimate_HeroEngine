using Ultimate_HeroEngine.Abilities;

namespace Ultimate_HeroEngine.Entities;

public abstract class Enemy : Entity
{
    public override int Level { get; set; }
    public Enemy(string name, int level, float hp, float skill, float defenseBuff) : base(name, level, hp, skill, defenseBuff) { }
    public override string GetCategoryName() => "Enemy";

}