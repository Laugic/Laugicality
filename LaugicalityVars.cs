using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality
{
    class LaugicalityVars //A list of all of the important vars!
    {
        static Mod _mod = ModLoader.GetMod("Laugicality");
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
        public static readonly HashSet<int> enpCs =
            new HashSet<int>
            {
                4, 50, 266, 267, 13, 14, 15, 222, 35, 36, 113, 114,  125, 126, 127, 128, 129, 130, 134, 135, 136, NPCID.DungeonGuardian, NPCID.PrimeLaser, 139, 262, 263, 264, 265, 245, 246, 247, 248, 249, 439, 440, 396, 397, 398, 400, 370, 371, 372, 373, 454, 455, 456, 457, 458, 459, 452, 454, 455, 456, 422, 493, 507, 517, 438, NPCID.TargetDummy, 379, 551, 552, 553, 554, 555, 556, 557, 558, 559, 560, 561, 562, 563, 564, 565, 566, 567, 568, 569, 570, 571, 572, 573, 574, 575, 576, 577, 578, NPCID.SandElemental, NPCID.IceGolem, _mod.NPCType("TitanBlast"), _mod.NPCType("LaserBall"), _mod.NPCType("AnDioLaserBall"), NPCID.Golem, 
            };

        public static readonly HashSet<int> eProjectiles =
            new HashSet<int>
            {
                31, 67, 68, 56, 71, 241, 179, 270, 55, 83, 99, 100, 96, 605, 101, 102, 257, 275, 276, 277, 262, 258, 259, 288, 384, 385, 386, 464, 465, 466, 467, 468, 490, 455, 454, 452, 657, 658, 670, 671, 672, 673, 673, 675, 676, 681, 682, 683, 684, 685, 686, 687, 
            };

        public static readonly HashSet<int> eBosses =
            new HashSet<int>
            {
                NPCID.KingSlime, NPCID.EyeofCthulhu, NPCID.BrainofCthulhu, _mod.NPCType("Hypothema"), NPCID.QueenBee, _mod.NPCType("Ragnar"), NPCID.SkeletronHead, _mod.NPCType("AnDio3"), NPCID.TheDestroyer, NPCID.SkeletronPrime, _mod.NPCType("TheAnnihilator"), _mod.NPCType("Slybertron"), _mod.NPCType("SteamTrain"), NPCID.Plantera, NPCID.Golem, NPCID.DukeFishron, NPCID.MoonLordCore
            };

        //Projectiles that are immune to time stop
        public static readonly HashSet<int> zProjectiles =
            new HashSet<int>
            {
                
            };

        //Projectiles that are immune to time stop while in the Etherial
        public static readonly HashSet<int> ezProjectiles =
            new HashSet<int>
            {
                _mod.ProjectileType("AndeBall"), _mod.ProjectileType("AndeEngery"), _mod.ProjectileType("AndeLaser3"), _mod.ProjectileType("AndeShard"), _mod.ProjectileType("AnDioEnergy"), _mod.ProjectileType("AnDioLaserBall"), _mod.ProjectileType("AnDioSpiral"), _mod.ProjectileType("AnDioSpiral2"), _mod.ProjectileType("DioBall"), _mod.ProjectileType("DioBallShot"), _mod.ProjectileType("DioEnergy"), _mod.ProjectileType("DioEnergyHoming"), _mod.ProjectileType("DioShard"),
            };

        //Bosses that are immune to time stop
        public static readonly HashSet<int> znpCs =
            new HashSet<int>
            {
                _mod.NPCType("LaserBall"), _mod.NPCType("AnDioLaserBall"),
            };

        public static readonly HashSet<int> eBad =
            new HashSet<int>
            {
                430, 431, 432, 433, 434, 435, 436
            };


        public static readonly HashSet<int> frigImmune =
            new HashSet<int>
            {
                13, 14, 15
            };

        public static readonly HashSet<int> etherial =
            new HashSet<int>
            {
                
            };


        public static readonly HashSet<int> obsidiumTiles =
            new HashSet<int>
            {
                0, _mod.TileType("ObsidiumRock"), _mod.TileType("ObsidiumBrick"), _mod.TileType("Lycoris"), _mod.TileType("Radiata"), _mod.TileType("ObsidiumOreBlock"), TileID.Obsidian,
            };
        /* -------------- SLIMEKING -------------- */
        public static readonly HashSet<int> slimeThrow =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief };
        public static readonly HashSet<int> slimeJump =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Conjurer };
        public static readonly HashSet<int> slimeMinion =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Destructionist };
        public static readonly HashSet<int> slimeVelocity =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Thief };

        /* -------------- BOSS1 -------------- */
        public static readonly HashSet<int> boss1Thorns =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Thief, (int)LaugicalityVars.ClassType.Destructionist };
        public static readonly HashSet<int> boss1Speed =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Illusionist };
        public static readonly HashSet<int> boss1Detect =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Conjurer };
        public static readonly HashSet<int> boss1Damage =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Destructionist, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Conjurer };

        /* -------------- BOSS2 -------------- */
        public static readonly HashSet<int> boss2Rage =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Destructionist };
        public static readonly HashSet<int> boss2Defence =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Illusionist };
        public static readonly HashSet<int> boss2Regen =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Thief, (int)LaugicalityVars.ClassType.Conjurer };
        public static readonly HashSet<int> boss2RBonus =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage };

        /* -------------- QUEENBEE -------------- */
        public static readonly HashSet<int> beeTrue =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Destructionist };
        public static readonly HashSet<int> beeRegen =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief, (int)LaugicalityVars.ClassType.Conjurer };
        public static readonly HashSet<int> beeMinions =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Illusionist };
        public static readonly HashSet<int> beeMDamage =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman };

        /* -------------- BOSS3 -------------- */
        public static readonly HashSet<int> boss3Damage =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Destructionist };
        public static readonly HashSet<int> boss3Defense =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Illusionist };
        public static readonly HashSet<int> boss3Speed =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief, (int)LaugicalityVars.ClassType.Conjurer };
        public static readonly HashSet<int> boss3Crit =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter };

        /* -------------- HARDMODE -------------- */
        public static readonly HashSet<int> hardDamage =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Destructionist };
        public static readonly HashSet<int> hardRegen =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief };
        public static readonly HashSet<int> hardMana =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Conjurer };
        public static readonly HashSet<int> hardObsid =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin };

        /* -------------- MECH1 -------------- */
        public static readonly HashSet<int> mech1Crit =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter };
        public static readonly HashSet<int> mech1Speed =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief, (int)LaugicalityVars.ClassType.Destructionist, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Conjurer };

        /* -------------- MECH2 -------------- */
        public static readonly HashSet<int> mech2Magic =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Destructionist, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Conjurer, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman };
        public static readonly HashSet<int> mech2Jump =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief };

        /* -------------- MECH3 -------------- */
        public static readonly HashSet<int> mech3Damage =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin };
        public static readonly HashSet<int> mech3Defense =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief, (int)LaugicalityVars.ClassType.Destructionist, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Conjurer };

        /* -------------- PLANT -------------- */
        public static readonly HashSet<int> plantBonus =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Destructionist, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Conjurer  };
        public static readonly HashSet<int> plantThorns =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief };

        /* -------------- GOLEM -------------- */
        public static readonly HashSet<int> golemCrit =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Assasin };
        public static readonly HashSet<int> golemRegen =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief, (int)LaugicalityVars.ClassType.Destructionist, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Conjurer };


        /* -------------- FISH -------------- */
        public static readonly HashSet<int> fishDouche =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter };
        public static readonly HashSet<int> fishSpeed =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief };
        public static readonly HashSet<int> fishMDamage =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Destructionist, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Conjurer };

        /* -------------- CULTIST -------------- */
        public static readonly HashSet<int> cultistDamage1 =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warrior, (int)LaugicalityVars.ClassType.Tank, (int)LaugicalityVars.ClassType.Paladin, (int)LaugicalityVars.ClassType.Sharpshooter, (int)LaugicalityVars.ClassType.Rogue, (int)LaugicalityVars.ClassType.Hunter, (int)LaugicalityVars.ClassType.Assasin, (int)LaugicalityVars.ClassType.Ninja, (int)LaugicalityVars.ClassType.Thief };
        public static readonly HashSet<int> cultistDamage2 =
            new HashSet<int> { (int)LaugicalityVars.ClassType.Warlock, (int)LaugicalityVars.ClassType.Wizard, (int)LaugicalityVars.ClassType.Mage, (int)LaugicalityVars.ClassType.Necromancer, (int)LaugicalityVars.ClassType.Sorcerer, (int)LaugicalityVars.ClassType.Shaman, (int)LaugicalityVars.ClassType.Destructionist, (int)LaugicalityVars.ClassType.Illusionist, (int)LaugicalityVars.ClassType.Conjurer };

    }
}
