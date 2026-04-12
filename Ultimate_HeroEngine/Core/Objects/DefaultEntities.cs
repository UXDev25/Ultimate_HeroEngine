using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core.Interfaces;
using Ultimate_HeroEngine.Entities;
using Ultimate_HeroEngine.Hierarchy.Entities.Heroes;

namespace Ultimate_HeroEngine.Core.Objects;

 public static class DefaultEntities
 {
        public static IReadOnlyList<Hero> Heroes { get; } = new List<Hero>
        {
            new Warrior("Michael", 1, KeyValues.DefWarriorHp, KeyValues.DefWarriorSkill, KeyValues.DefDefense, new List<Ability>(), KeyValues.DefWarriorArmor, KeyValues.MichaelCry),
            new Mage("Cheich", 1, KeyValues.DefMageHp, KeyValues.DefMageSkill, KeyValues.DefDefense, new List<Ability>(), KeyValues.DefMageMana, KeyValues.DefMageArk),
            new Rogue("Gonzalez", 1, KeyValues.DefRogueHp
                , KeyValues.DefRogueSkill, KeyValues.DefDefense, new List<Ability>(), KeyValues.DefRogueMult, KeyValues.DefRogueDaggers),
        };
        
        public static IReadOnlyList<Enemy> Enemies { get; } = new List<Enemy>
        {
            //Minions
                new Minion("Little Goblin", 1, KeyValues.DefMinionHp, KeyValues.DefMinionSkill, KeyValues.DefMinionDefenseBuff),
                new Minion("Slime", 1, KeyValues.DefMinionHp, KeyValues.DefMinionSkill, KeyValues.DefMinionDefenseBuff),
                new Minion("Skeleton Warrior", 1, KeyValues.DefMinionHp, KeyValues.DefMinionSkill, KeyValues.DefMinionDefenseBuff),
                new Minion("Rabid Wolf", 1, KeyValues.DefMinionHp, KeyValues.DefMinionSkill, KeyValues.DefMinionDefenseBuff),
                new Minion("Bandit Scout", 1, KeyValues.DefMinionHp, KeyValues.DefMinionSkill, KeyValues.DefMinionDefenseBuff),
                new Minion("Cave Bat", 1, KeyValues.DefMinionHp, KeyValues.DefMinionSkill, KeyValues.DefMinionDefenseBuff),
                
                //Elites
                new Elite("Elite Guard", 1, KeyValues.DefEliteHp, KeyValues.DefEliteSkill, KeyValues.DefEliteDefenseBuff, new List<Ability>(), KeyValues.DefEliteMana),
                new Elite("Orc Warlord", 1, KeyValues.DefEliteHp, KeyValues.DefEliteSkill, KeyValues.DefEliteDefenseBuff, new List<Ability>(), KeyValues.DefEliteMana),
                new Elite("Dark Cultist", 1, KeyValues.DefEliteHp, KeyValues.DefEliteSkill, KeyValues.DefEliteDefenseBuff, new List<Ability>(), KeyValues.DefEliteMana),
                new Elite("Armored Golem", 1, KeyValues.DefEliteHp, KeyValues.DefEliteSkill, KeyValues.DefEliteDefenseBuff, new List<Ability>(), KeyValues.DefEliteMana),
                new Elite("Shadow Assassin", 1, KeyValues.DefEliteHp, KeyValues.DefEliteSkill, KeyValues.DefEliteDefenseBuff, new List<Ability>(), KeyValues.DefEliteMana),
                
                //Bosses
                new BugBoss("Scary Monster",1, KeyValues.DefBugBossHp, KeyValues.DefBugBossSkill, KeyValues.DefBugBossDefenseBuff, new List<Ability>(), KeyValues.DefBugBossDmgMult, KeyValues.DefBugBossArmor, KeyValues.DefBugBossMana),
                new BugBoss("Arachnid Queen", 1, KeyValues.DefBugBossHp, KeyValues.DefBugBossSkill, KeyValues.DefBugBossDefenseBuff, new List<Ability>(), KeyValues.DefBugBossDmgMult, KeyValues.DefBugBossArmor, KeyValues.DefBugBossMana),
                new BugBoss("Ancient Dragon", 1, KeyValues.DefBugBossHp, KeyValues.DefBugBossSkill, KeyValues.DefBugBossDefenseBuff, new List<Ability>(), KeyValues.DefBugBossDmgMult, KeyValues.DefBugBossArmor, KeyValues.DefBugBossMana),
                new BugBoss("Void Behemoth", 1, KeyValues.DefBugBossHp, KeyValues.DefBugBossSkill, KeyValues.DefBugBossDefenseBuff, new List<Ability>(), KeyValues.DefBugBossDmgMult, KeyValues.DefBugBossArmor, KeyValues.DefBugBossMana),
                new BugBoss("King of the Undead", 1, KeyValues.DefBugBossHp, KeyValues.DefBugBossSkill, KeyValues.DefBugBossDefenseBuff, new List<Ability>(), KeyValues.DefBugBossDmgMult, KeyValues.DefBugBossArmor, KeyValues.DefBugBossMana)
        };

        /// <summary>
        /// Sets Random enemies from the Default catalogue of enemy instantiations.
        /// </summary>
        /// <param name="isBossFight"> true if the battle will be a bossfight</param>
        /// <param name="aproxLevel"> the aproximate level of the heroes to cap new enemies level</param>
        /// <returns>a List with random Enemy instances</returns>
        public static List<Enemy> GetRandomEnemies(bool isBossFight, int aproxLevel)
        {
            var rand = new Random();
            List<Enemy> randomEnemies = new List<Enemy>();
            
            List<Enemy> bosses = Enemies.Where(enemy => enemy is BugBoss).ToList();
            List<Enemy> notBosses = Enemies.Where(enemy => enemy is not BugBoss).ToList();
            
            if (isBossFight) 
            {
                Enemy originalBoss = bosses[Random.Shared.Next(0, bosses.Count)];
                randomEnemies.Add((Enemy)originalBoss.Clone()); 
            }
            int targetTeamSize = isBossFight ? KeyValues.BossTeamSize : KeyValues.DefTeamSize;
            while (randomEnemies.Count < targetTeamSize)
            {
                Enemy originalMinion = notBosses[Random.Shared.Next(0, notBosses.Count)];
                randomEnemies.Add((Enemy)originalMinion.Clone());
            }

            foreach (var enemy in randomEnemies)
            {
                enemy.Level += rand.Next(aproxLevel, KeyValues.RandomLevelRange);
                if (enemy is IUseAbility notMinion) notMinion.AssignAbilitiesToUser();
            }

            return randomEnemies;
        }
 }
