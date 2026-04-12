using Ultimate_HeroEngine.Abilities;
using Ultimate_HeroEngine.Core.Enums;
using Ultimate_HeroEngine.Core.Interfaces;

namespace Ultimate_HeroEngine.Core.Objects;

    public static class AbilityCatalog
    {
        public static IReadOnlyList<Ability> GameAbilities { get; } = new List<Ability>
        {
            
            // ==========================================
            //                 ATTACKS
            // ==========================================
            new Attack("Quick Slash", cost: 0, ERarity.Common, power: 15, ETarget.SingleEnemy, user: null, classType: EClasses.Rogue),
            new Attack("Poison Dart", cost: 10, ERarity.Common, power: 20, ETarget.SingleEnemy, user: null, classType: EClasses.Rogue),
            new Attack("Magic Missile", cost: 5, ERarity.Common, power: 18, ETarget.SingleEnemy, user: null, classType: EClasses.Mage),
            new Attack("Heavy Smash", cost: 25, ERarity.Rare, power: 45, ETarget.SingleEnemy, user: null, classType: EClasses.Warrior),
            new Attack("Fireball", cost: 35, ERarity.Rare, power: 30, ETarget.AllEnemies, user: null, classType: EClasses.Mage),
            new Attack("Whirlwind Slash", cost: 30, ERarity.Rare, power: 35, ETarget.AllEnemies, user: null, classType: EClasses.Warrior),
            new Attack("Shadow Strike", cost: 35, ERarity.Rare, power: 50, ETarget.SingleEnemy, user: null, classType: EClasses.Rogue),
            new Attack("Arrow Rain", cost: 50, ERarity.Epic, power: 60, ETarget.AllEnemies, user: null, classType: EClasses.Rogue),
            new Attack("Assassin's Strike", cost: 40, ERarity.Epic, power: 90, ETarget.SingleEnemy, user: null, classType: EClasses.Rogue),
            new Attack("Thunderstrike", cost: 45, ERarity.Epic, power: 70, ETarget.SingleEnemy, user: null, classType: EClasses.Mage),
            new Attack("Earthquake", cost: 60, ERarity.Epic, power: 55, ETarget.Everyone, user: null, classType: EClasses.Mage),
            new Attack("Meteor Swarm", cost: 90, ERarity.Legendary, power: 120, ETarget.AllEnemies, user: null, classType: EClasses.Mage),
            new Attack("Dragon's Breath", cost: 85, ERarity.Legendary, power: 100, ETarget.AllEnemies, user: null, classType: EClasses.Mage),

            // ==========================================
            //                 DEFENSES
            // ==========================================
            new Defense("Defensive Stance", cost: 10, ERarity.Common, power: 20, ETarget.Self, user: null, classType: EClasses.Warrior),
            new Defense("Wooden Shield", cost: 15, ERarity.Common, power: 25, ETarget.SingleAlly, user: null, classType: EClasses.Warrior),
            new Defense("Dodge", cost: 5, ERarity.Common, power: 15, ETarget.Self, user: null, classType: EClasses.Rogue),
            new Defense("Stone Wall", cost: 40, ERarity.Rare, power: 50, ETarget.AllAllies, user: null, classType: EClasses.Warrior),
            new Defense("Magic Barrier", cost: 25, ERarity.Rare, power: 35, ETarget.SingleAlly, user: null, classType: EClasses.Mage),
            new Defense("Iron Skin", cost: 30, ERarity.Epic, power: 75, ETarget.Self, user: null, classType: EClasses.Warrior),
            new Defense("Phalanx Formation", cost: 45, ERarity.Epic, power: 60, ETarget.AllAllies, user: null, classType: EClasses.Warrior),
            new Defense("Mirror Image", cost: 35, ERarity.Epic, power: 45, ETarget.Self, user: null, classType: EClasses.Mage),
            new Defense("Holy Aegis", cost: 80, ERarity.Legendary, power: 100, ETarget.AllAllies, user: null, classType: EClasses.Warrior),
            new Defense("Absolute Invulnerability", cost: 90, ERarity.Legendary, power: 200, ETarget.Self, user: null, classType: EClasses.Mage),

            // ==========================================
            //                 HEALING
            // ==========================================
            new Healing("Basic Bandages", cost: 15, ERarity.Common, power: 30, ETarget.SingleAlly, user: null, classType: EClasses.Rogue),
            new Healing("Healing Potion", cost: 20, ERarity.Common, power: 40, ETarget.Self, user: null, classType: EClasses.Rogue),
            new Healing("Herbal Brew", cost: 10, ERarity.Common, power: 25, ETarget.SingleAlly, user: null, classType: EClasses.Rogue),
            new Healing("Mending Aura", cost: 45, ERarity.Rare, power: 35, ETarget.AllAllies, user: null, classType: EClasses.Mage),
            new Healing("Healing Rain", cost: 40, ERarity.Rare, power: 35, ETarget.AllAllies, user: null, classType: EClasses.Mage),
            new Healing("Rejuvenation", cost: 60, ERarity.Epic, power: 80, ETarget.SingleAlly, user: null, classType: EClasses.Mage),
            new Healing("Cleansing Light", cost: 55, ERarity.Epic, power: 75, ETarget.SingleAlly, user: null, classType: EClasses.Mage),
            new Healing("Nature's Blessing", cost: 70, ERarity.Epic, power: 60, ETarget.AllAllies, user: null, classType: EClasses.Mage),
            new Healing("Divine Light", cost: 100, ERarity.Legendary, power: 150, ETarget.AllAllies, user: null, classType: EClasses.Mage),
            new Healing("Miracle", cost: 120, ERarity.Legendary, power: 999, ETarget.Everyone, user: null, classType: EClasses.Mage),

            // ==========================================
            //                 SUPPORT
            // ==========================================
            new Support("Awkward Dance", cost: 5, ERarity.Common, power: 0, ETarget.Everyone, user: null, EEffect.Nothing, classType: EClasses.Rogue),
            new Support("Random Trivia", cost: 5, ERarity.Common, power: 0, ETarget.Everyone, user: null, EEffect.TellFacts, classType: EClasses.Mage),
            new Support("Battle Cry", cost: 20, ERarity.Rare, power: 0, ETarget.AllAllies, user: null, EEffect.Cheer, classType: EClasses.Warrior),
            new Support("Enrage", cost: 25, ERarity.Rare, power: 0, ETarget.SingleAlly, user: null, EEffect.Cheer, classType: EClasses.Warrior),
            new Support("Motivational Speech", cost: 35, ERarity.Epic, power: 0, ETarget.AllAllies, user: null, EEffect.Cheer, classType: EClasses.Warrior),
            new Support("History Lesson", cost: 30, ERarity.Epic, power: 0, ETarget.Everyone, user: null, EEffect.TellFacts, classType: EClasses.Warrior),
            new Support("Heroic Anthem", cost: 50, ERarity.Epic, power: 0, ETarget.AllAllies, user: null, EEffect.Cheer, classType: EClasses.Warrior),
            new Support("Kamikaze", cost: 0, ERarity.Epic, power: 0, ETarget.SingleEnemy, user: null, EEffect.InstaKill, classType: EClasses.Warrior),
            new Support("Blood Pact", cost: 0, ERarity.Legendary, power: 0, ETarget.Self, user: null, EEffect.InstaKill, classType: EClasses.Warrior),
            new Support("Ultimate Sacrifice", cost: 0, ERarity.Legendary, power: 0, ETarget.AllAllies, user: null, EEffect.InstaKill, classType: EClasses.Warrior),
            new Support("Doomsday Prophecy", cost: 75, ERarity.Legendary, power: 0, ETarget.Everyone, user: null, EEffect.TellFacts, classType: EClasses.Warrior),
            new Support("Martyr's Spirit", cost: 0, ERarity.Legendary, power: 0, ETarget.AllAllies, user: null, EEffect.InstaKill, classType: EClasses.Warrior)
        };

        /// <summary>
        /// Gets a random set of abilities
        /// </summary>
        /// <param name="user">The object that will be used to get abilities of their own ClassType</param>
        /// <returns>a list of random Ability instances</returns>
        public static List<Ability> GetRandomAbilities(IUseAbility user)
        {
            var rand = new Random();
            List<Ability> compatibleAbilities = GameAbilities.Where(ability => user.GetType().Name == ability.ClassType.ToString()).ToList();
            if (compatibleAbilities.Count == 0) return GameAbilities.ToList();
            List<Ability> randomAbilities = new List<Ability>();
            for (int i = 0; i < KeyValues.MaxAbilityNum; i++)
            {
                randomAbilities.Add(compatibleAbilities[rand.Next(0, (compatibleAbilities.Count - 1))]);
            }
            return randomAbilities;
        }
    }
    