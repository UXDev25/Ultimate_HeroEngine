using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core;
using Ultimate_HeroEngine.Core.Interfaces;
using Ultimate_HeroEngine.Core.Objects;
using Ultimate_HeroEngine.Hierarchy;

namespace Ultimate_HeroEngine.Entities;

public class BugBoss : Enemy, IUseAbility
{
    public List<Ability> Abilities { get; set; }
    public float DmgMult { get; set; }
    public int Armor { get; set; }
    public int Mana { get; set; }
    public int CostStat 
    { 
        get => Mana;
        set
        {
            Mana = value;
        }
    }

    public BugBoss(string name, int level, int hp, float skill, float defenseBuff, List<Ability> abilities, float dmgMult, int armor, int mana) : base(name, level, hp, skill, defenseBuff)
    {
        Armor = armor;
        DmgMult = dmgMult;
        Mana = mana;
        Abilities = Abilities = AbilityCatalog.GetRandomAbilities(this);
    }
    
    public override string ToString() => base.ToString() + String.Format(KeyValues.BossIntroduce, DmgMult, Mana, Armor);
    
    public override void ReceiveDamage(float damage)
    {
        float actualDamage = damage - (1 + (DefenseBuff / 10)) - (DefenseBuff / 10) * (Armor / 100);
        actualDamage = Math.Max(KeyValues.MinDefaultDamage, actualDamage);
        Hp -= actualDamage;
        Console.WriteLine(Messages.Recieved, GetType().Name.ToUpper(), Name, actualDamage, Hp, MaxHp);
    }

    public override void AttackMeth(Entity? target)
    {
        Console.WriteLine(Messages.Attack, GetType().Name.ToUpper(), Name, target!.GetType().Name, target.Name);
        target.ReceiveDamage(Skill * KeyValues.DefBossPow * DmgMult);
    }
    
    //**Abilities
    public void UseAbility(int abilityIndex, ITargetable? target)
    {
        if (target is Entity ent) Console.WriteLine(Messages.UseAbility, ent.GetType().Name, Name, Abilities[abilityIndex].Name);
        if (target is Team team)
        {
            Console.WriteLine(Messages.UseAbility, team.Members.GetType().Name, Name, Abilities[abilityIndex].Name);
            foreach (var member in team.Members)
            {
                Abilities[abilityIndex].Execute(member);
            }
        }
        else Abilities[abilityIndex].Execute((Entity)target!);
    }
    
    public void AssignAbilitiesToUser()
    {
        Abilities.ForEach(ability => ability.User = this);
    }
    
    public override void LevelUp()
    {
        base.LevelUp();
        Mana += KeyValues.DefManaIncrease;
        Armor += KeyValues.DefArmorIncrease;
        DmgMult += KeyValues.DefMultIncrease;
    }
    
}