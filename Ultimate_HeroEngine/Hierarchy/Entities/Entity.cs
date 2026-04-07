using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Interfaces;

namespace Ultimate_HeroEngine.Entities;

public abstract class Entity : IAttack, ITargetable
{
    private int _level;
    private float _hp;
    
    public string Name { get; set; }
    public int Level { get => _level;
        set
        {
            if (value < _level) throw new ArgumentException("You cannot decrease the level of an entity");
            for (int i = _level; i < value; i++)
            {
                LevelUp();
            }
            _level = value;
        }
    }
    public float Hp { get => _hp;
        set
        {
            if (value > MaxHp) throw new ArgumentException("You cannot insert a higher HP than the maximum value");
            _hp = value;
        }
    }
    public float MaxHp { get; set; }
    public float Skill { get; set; }
    public float DefenseBuff { get; set; }
    

    public Entity(string name, int level, float maxHp, float skill, int defenseBuff)
    {
        Name = name;
        _level = 1;
        Level = level;
        Hp = MaxHp;
        MaxHp = maxHp;
        Skill = skill;
        DefenseBuff = defenseBuff;
    }

    public override string ToString() => String.Format(KeyValues.DefIntroduce, GetType().Name, Name, Level, Hp, MaxHp);

    public virtual void AttackMeth(Entity target)
    {
        Console.WriteLine(UI.Attack, GetType().Name.ToUpper(), Name, target.GetType().Name, target.Name);
        target.RecieveDamage(Skill * KeyValues.DefPower);
    }

    public virtual void RecieveDamage(float damage)
    {
        float difference = Hp - damage + (DefenseBuff / 10);
        Console.WriteLine(UI.Recieved, GetType().Name.ToUpper(), Name, difference, Hp, MaxHp);
        Hp = difference;
    }
    
    public virtual void LevelUp()
    {
        MaxHp += KeyValues.DefHpIncrease;
        DefenseBuff += KeyValues.DefDefIncrease;
        Skill += KeyValues.DefSkillIncrease;
    }
    public virtual string GetCategoryName() => GetType().Name; 
}