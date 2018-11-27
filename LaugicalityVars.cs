using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality
{
    class LaugicalityVars //A list of all of the important vars!
    {
        static Mod mod = ModLoader.GetMod("Laugicality");
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
        /* -------------- Etherial NPCs and Projectiles -------------- */
        public static readonly HashSet<int> ENPCs =
            new HashSet<int>
            {
                4, 50, 266, 267, 13, 14, 15, 222, 35, 36, 113, 114, 115, 116, 125, 126, 127, 128, 129, 130, 134, 135, 136, 139, 262, 263, 264, 265, 245, 246, 247, 248, 249, 439, 440, 396, 397, 398, 400, 370, 371, 372, 373, 454, 455, 456, 457, 458, 459, 452, 454, 455, 456, 422, 493, 507, 517, 438, 379, 551, 552, 553, 554, 555, 556, 557, 558, 559, 560, 561, 562, 563, 564, 565, 566, 567, 568, 569, 570, 571, 572, 573, 574, 575, 576, 577, 578, NPCID.SandElemental, NPCID.IceGolem
            };

        public static readonly HashSet<int> EProjectiles =
            new HashSet<int>
            {
                31, 67, 68, 56, 71, 241, 179, 270, 55, 83, 99, 100, 96, 605, 101, 102, 257, 275, 276, 277, 262, 258, 259, 288, 384, 385, 386, 464, 465, 466, 467, 468, 490, 455, 454, 452, 657, 658, 670, 671, 672, 673, 673, 675, 676, 681, 682, 683, 684, 685, 686, 687, 
            };

        public static readonly HashSet<int> EBosses =
            new HashSet<int>
            {
                NPCID.KingSlime, NPCID.EyeofCthulhu, mod.NPCType("DuneSharkron"), NPCID.BrainofCthulhu, mod.NPCType("Hypothema"), NPCID.QueenBee, mod.NPCType("Ragnar"), NPCID.SkeletronHead, mod.NPCType("AnDio3"), NPCID.WallofFlesh, NPCID.TheDestroyer, NPCID.SkeletronPrime, mod.NPCType("TheAnnihilator"), mod.NPCType("Slybertron"), mod.NPCType("SteamTrain"), NPCID.Plantera, NPCID.Golem, NPCID.DukeFishron, NPCID.MoonLordCore
            };

        public static readonly HashSet<int> ZProjectiles =
            new HashSet<int>
            {
                
            };

        public static readonly HashSet<int> ZNPCs =
            new HashSet<int>
            {
                
            };

        public static readonly HashSet<int> EBad =
            new HashSet<int>
            {
                430, 431, 432, 433, 434, 435, 436
            };


        public static readonly HashSet<int> FrigImmune =
            new HashSet<int>
            {
                13, 14, 15
            };

        public static readonly HashSet<int> Etherial =
            new HashSet<int>
            {
                
            };
        /* -------------- SLIMEKING -------------- */
        public static readonly HashSet<int> SlimeThrow =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief };
        public static readonly HashSet<int> SlimeJump =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Conjurer };
        public static readonly HashSet<int> SlimeMinion =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Destructionist };
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
