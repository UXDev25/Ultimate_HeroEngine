using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Enums;
using Ultimate_HeroEngine.Core.Interfaces;
using Ultimate_HeroEngine.Hierarchy;
using Ultimate_HeroEngine.Logic.ProgramEngine;

namespace Ultimate_HeroEngine.Entities;

public abstract class Entity : IAttack, ITargetable
{
    private int _level;
    private float _hp;
    private bool _isDefeated;
    
    public string Name { get; set; }
    public virtual int Level { get => _level;
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
            if (value > MaxHp)
            {
                _hp = MaxHp;
                return;
            }
            _hp = value < 0 ? 0 : value;
            _isDefeated = _hp <= 0;
            if (_isDefeated) Defeated();
        }
    }
    public float MaxHp { get; set; }
    public float Skill { get; set; }
    public float DefenseBuff { get; set; }
    public bool IsDefeated { get => _isDefeated; }

    public Entity(string name, int level, float maxHp, float skill, float defenseBuff)
    {
        Name = name;
        _level = 1;
        Level = level;
        MaxHp = maxHp;
        Hp = maxHp;
        Skill = skill;
        DefenseBuff = defenseBuff;
    }

    public override string ToString() => String.Format(KeyValues.DefIntroduce, GetType().Name, Name, Level, Hp, MaxHp);

        /// <summary>
    /// Executes a standard attack against the specified target entity. 
    /// Calculates the outgoing damage based on the entity's current skill level and default power modifiers.
    /// </summary>
    /// <param name="target">The entity that will receive the attack.</param>
    public virtual void AttackMeth(Entity? target)
    {
        Console.WriteLine(Messages.Attack, GetType().Name.ToUpper(), Name, target!.GetType().Name, target.Name);
        target.ReceiveDamage(Skill * KeyValues.DefPower);
    }

    /// <summary>
    /// Processes incoming damage by applying defense mitigation and ensuring a minimum damage threshold. 
    /// It updates the entity's health, records the damage in the global combat statistics, and displays the result.
    /// </summary>
    /// <param name="damage">The raw incoming damage value before defensive calculations are applied.</param>
    public virtual void ReceiveDamage(float damage)
    {
        float actualDamage = damage - (DefenseBuff / 10f);
        actualDamage = Math.Max(KeyValues.MinDefaultDamage, actualDamage);
        StatCalculator.LastDamagePoint = actualDamage;
        StatCalculator.AllCombatDamage += StatCalculator.LastDamagePoint;
        Hp -= actualDamage;
        Console.WriteLine(Messages.Recieved, GetType().Name.ToUpper(), Name, actualDamage, Hp, MaxHp);
    }

    /// <summary>
    /// Increases the entity's core statistics (Max HP, Defense, and Skill) by predefined default values 
    /// to represent leveling up, and displays a level-up message.
    /// </summary>
    public virtual void LevelUp()
    {
        Console.WriteLine(Messages.LevelUp, GetType().Name, Name);
        MaxHp += KeyValues.DefHpIncrease;
        DefenseBuff += KeyValues.DefDefIncrease;
        Skill += KeyValues.DefSkillIncrease;
    }

    /// <summary>
    /// Retrieves the category or class name of the entity based on its system type.
    /// </summary>
    /// <returns>A string representing the exact class name of the entity.</returns>
    public virtual string GetCategoryName() => GetType().Name;

    /// <summary>
    /// Handles the entity's defeat state by explicitly setting its health to zero 
    /// and displaying a specific defeat message in the console.
    /// </summary>
    public virtual void Defeated()
    {
        Console.WriteLine(Messages.DefeatMsg, GetType().Name, Name);
        _hp = 0;
    }

    /// <summary>
    /// Creates a duplicate of the current entity. It performs a standard shallow copy, 
    /// but ensures a deep copy of the abilities list if the entity is an ability user, 
    /// preventing the clone and the original from sharing the same ability references.
    /// </summary>
    /// <returns>A new <see cref="Entity"/> instance that is a copy of the current entity.</returns>
    public Entity Clone()
    {
        Entity clonedEntity = (Entity)this.MemberwiseClone();
        if (this is IUseAbility originalUser && clonedEntity is IUseAbility clonedUser)
        {
            clonedUser.Abilities = new List<Ability>();
            foreach (var ability in originalUser.Abilities)
            {
                clonedUser.Abilities.Add(ability.Clone());
            }
            clonedUser.AssignAbilitiesToUser();
        }
        return clonedEntity;
    }
}