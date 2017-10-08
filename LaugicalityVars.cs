using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laugicality
{
    class LaugicalityVars //A list of all of the important vars!
    {
        public enum ClassType
        {
            Undefined, //(No class) 0
                       /*Melee*/
            Warrior, //(Dmg) 1
            Tank, //(Def) 2
            Paladin, //(Util/Survivability) 3
                     /*Magic*/
            Warlock, //(Dmg) 4
            Wizard, //(Mana) 5
            Mage, //(Util/Survivability) 6
                  /*Range*/
            Sharpshooter, //(Dmg) 7
            Rogue, //(Mobility) 8
            Hunter, //(Util/Survivability) 9
                    /*Summn*/
            Necromancer, //(Dmg) 10
            Sorcerer, //(Minions & Mana) 11
            Shaman, //(Util/Survivability) 12
                    /*Throw*/
            Assasin, //(Dmg) 13
            Ninja, //(Vel & Sp & Mobility) 14
            Thief, //(Util/Survivability) 15
                   /*Mystc:*/
            Destructionist, //(Dmg) 16
            Illusionist, //(BuffDur & Mobility) 17
            Conjurer //(Util/Survivability) 18
        }
        /* -------------- SLIMEKING -------------- */ 
        public static readonly HashSet<int> SlimeThrow =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief };
        public static readonly HashSet<int> SlimeJump =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Illusionist };
        public static readonly HashSet<int> SlimeMinion =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Destructionist, (int)LaugicalityVars.ClassType.Conjurer };
        public static readonly HashSet<int> SlimeVelocity =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Thief };

        /* -------------- BOSS1 -------------- */
        public static readonly HashSet<int> Boss1Thorns =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Thief, (int)LaugicalityVars.ClassType.Destructionist };
        public static readonly HashSet<int> Boss1Speed =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Illusionist };
        public static readonly HashSet<int> Boss1Detect =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Conjurer };
        public static readonly HashSet<int> Boss1Damage =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Destructionist, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Conjurer };

        /* -------------- BOSS2 -------------- */
        public static readonly HashSet<int> Boss2Rage =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Destructionist };
        public static readonly HashSet<int> Boss2Defence =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Illusionist };
        public static readonly HashSet<int> Boss2Regen =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Thief, (int)LaugicalityVars.ClassType.Conjurer };
        public static readonly HashSet<int> Boss2RBonus =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage };

        /* -------------- QUEENBEE -------------- */
        public static readonly HashSet<int> BeeTrue =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Destructionist };
        public static readonly HashSet<int> BeeRegen =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief, (int)LaugicalityVars.ClassType.Conjurer };
        public static readonly HashSet<int> BeeMinions =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Illusionist };
        public static readonly HashSet<int> BeeMDamage =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman };

        /* -------------- BOSS3 -------------- */
        public static readonly HashSet<int> Boss3Damage =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Destructionist };
        public static readonly HashSet<int> Boss3Defense =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Illusionist };
        public static readonly HashSet<int> Boss3Speed =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief, (int)LaugicalityVars.ClassType.Conjurer };
        public static readonly HashSet<int> Boss3Crit =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter };

        /* -------------- HARDMODE -------------- */
        public static readonly HashSet<int> HardDamage =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Destructionist };
        public static readonly HashSet<int> HardRegen =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief };
        public static readonly HashSet<int> HardMana =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Conjurer };
        public static readonly HashSet<int> HardObsid =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin };

        /* -------------- MECH1 -------------- */
        public static readonly HashSet<int> Mech1Crit =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter };
        public static readonly HashSet<int> Mech1Speed =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief, (int)LaugicalityVars.ClassType.Destructionist, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Conjurer };

        /* -------------- MECH2 -------------- */
        public static readonly HashSet<int> Mech2Magic =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Destructionist, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Conjurer, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman };
        public static readonly HashSet<int> Mech2Jump =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief };

        /* -------------- MECH3 -------------- */
        public static readonly HashSet<int> Mech3Damage =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin };
        public static readonly HashSet<int> Mech3Defense =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief, (int)LaugicalityVars.ClassType.Destructionist, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Conjurer };

        /* -------------- PLANT -------------- */
        public static readonly HashSet<int> PlantBonus =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Destructionist, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Conjurer  };
        public static readonly HashSet<int> PlantThorns =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief };

        /* -------------- GOLEM -------------- */
        public static readonly HashSet<int> GolemCrit =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Assasin };
        public static readonly HashSet<int> GolemRegen =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief, (int)LaugicalityVars.ClassType.Destructionist, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Conjurer };


        /* -------------- FISH -------------- */
        public static readonly HashSet<int> FishDouche =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter };
        public static readonly HashSet<int> FishSpeed =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief };
        public static readonly HashSet<int> FishMDamage =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Destructionist, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Conjurer };

        /* -------------- CULTIST -------------- */
        public static readonly HashSet<int> CultistDamage1 =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief };
        public static readonly HashSet<int> CultistDamage2 =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Destructionist, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Conjurer };

    }
}
