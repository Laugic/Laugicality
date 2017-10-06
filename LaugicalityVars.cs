using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laugicality
{
    class LaugicalityVars
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
            new HashSet<int> { (int)ClassType.Assasin, (int)ClassType.Ninja, (int)ClassType.Thief };
        public static readonly HashSet<int> SlimeJump =
            new HashSet<int> { (int)ClassType.Tank, (int)ClassType.Paladin, (int)ClassType.Rogue, (int)ClassType.Ninja, (int)ClassType.Illusionist };
        public static readonly HashSet<int> SlimeMinion =
            new HashSet<int> { (int)ClassType.Warrior, (int)ClassType.Paladin, (int)ClassType.Warlock, (int)ClassType.Wizard, (int)ClassType.Mage, (int)ClassType.Sharpshooter, (int)ClassType.Hunter, (int)ClassType.Necromancer, (int)ClassType.Sorcerer, (int)ClassType.Sorcerer, (int)ClassType.Destructionist, (int)ClassType.Conjurer };
        public static readonly HashSet<int> SlimeVelocity =
            new HashSet<int> { (int)ClassType.Assasin, (int)ClassType.Thief };

        /* -------------- BOSS1 -------------- */
        public static readonly HashSet<int> Boss1Thorns =
            new HashSet<int> { (int)ClassType.Warrior, (int)ClassType.Warlock, (int)ClassType.Sharpshooter, (int)ClassType.Necromancer, (int)ClassType.Thief, (int)ClassType.Destructionist };
        public static readonly HashSet<int> Boss1Speed =
            new HashSet<int> { (int)ClassType.Tank, (int)ClassType.Wizard, (int)ClassType.Rogue, (int)ClassType.Shaman, (int)ClassType.Ninja, (int)ClassType.Illusionist };
       
    }
}
