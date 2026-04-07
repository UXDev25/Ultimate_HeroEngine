namespace Ultimate_HeroEngine.Abilities;
using Core.Enums;

public abstract class Ability : IComparer<Ability>
{
    public string Name { get; set; }
    public int Cost { get; set; }
    public ERarity Rarity { get; set; }
    public int Power { get; set; }
    public ETarget TargetType { get; set; }
    public int UserSkill { get; set; }


    public Ability(string name, int cost, ERarity rarity, int power, ETarget targetType, int userSkill)
    {
        Name = name;
        Cost = cost;
        Rarity = rarity;
        Power = power;
        TargetType = targetType;
        UserSkill = userSkill;
    }
    
    
    //***IComparer***
    public int Compare(Ability? x, Ability? y)
    {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;
        return x.Rarity.CompareTo(y.Rarity);
    }
}