using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace Laugicality
{
    public partial class LaugicalityPlayer
    {
        //Mystic vars
        public float mysticDamage = 1f;
        public float mysticDuration = 1f;
        public int mysticMode = 1; //1 = Destruction, 2 = Illusion, 3 = Conjuration
        public float illusionDamage = 1f;
        public float destructionDamage = 1f;
        public float conjurationDamage = 1f;
        public int illusionPower = 1;
        public int destructionPower = 1;
        public int conjurationPower = 1;
        public int mysticSwitchCool = 0;
        public int mysticSwitchCoolRate = 1;
        public bool mysticSteamBurst = false;
        public bool mysticShroomBurst = false;
        public bool mysticSandBurst = false;
        public int mysticSpiralBurst = 0;
        public int mysticSpiralDelay = 0;
        public int mysticSteamSpiralBurst = 0;
        public int mysticSteamSpiralDelay = 0;
        public bool mysticEruption = false;
        public int mysticErupting = 0;
        public bool mysticEruptionBurst = false;
        public bool mysticMarblite = false;
        public bool andioChestplate = false;
        public bool andioChestguard = false;
        public bool midnight = false;
        public bool mysticHold = false;
        public bool magmatic = false;
        public int mysticCrit = 4;

        /// <summary>
        /// Refactor This to be short
        /// </summary>
        public void mysticSwitch()
        {
            mysticMode += 1;
            if (mysticMode > 3)
                mysticMode = 1;
            if (mysticSwitchCool <= 0)
            {
                if (mysticShroomBurst)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 2.5f, -6.25f, mod.ProjectileType("ShroomBurst"), (int)(10 * mysticDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 5, -5, mod.ProjectileType("ShroomBurst"), (int)(10 * mysticDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, -5, -5, mod.ProjectileType("ShroomBurst"), (int)(10 * mysticDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, -2.5f, -6.25f, mod.ProjectileType("ShroomBurst"), (int)(10 * mysticDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 2.5f / 2, -6.75f, mod.ProjectileType("ShroomBurst"), (int)(10 * mysticDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 3.75f, -5.75f, mod.ProjectileType("ShroomBurst"), (int)(10 * mysticDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, -3.75f, -5.75f, mod.ProjectileType("ShroomBurst"), (int)(10 * mysticDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, -2.5f / 2, -6.75f, mod.ProjectileType("ShroomBurst"), (int)(10 * mysticDamage), 3, Main.myPlayer);

                    mysticSwitchCool = 60;
                }
                if (mysticEruption)
                {
                    mysticErupting += 90;
                    mysticSwitchCool = 180;
                }
                if (magmatic)
                {
                    mysticErupting += 90;
                    mysticSwitchCool = 180;
                }
                if (mysticSandBurst)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y + 16, 2, 0, mod.ProjectileType("AncientRune"), (int)(12 * mysticDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y + 16, -2, 0, mod.ProjectileType("AncientRune"), (int)(12 * mysticDamage), 3, Main.myPlayer);

                    mysticSwitchCool = 180;
                }
                if (mysticEruptionBurst)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y + 16, 4, 0, mod.ProjectileType("EruptionBurst"), (int)(12 * mysticDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y + 16, -4, 0, mod.ProjectileType("EruptionBurst"), (int)(12 * mysticDamage), 3, Main.myPlayer);
                    mysticErupting += 45;

                    mysticSwitchCool = 210;
                }
                if (andioChestguard)
                {
                    mysticSpiralBurst += 120;
                    mysticSwitchCool = 210;
                }
                if (mysticSteamBurst)
                {
                    mysticSteamSpiralBurst += 145;
                    mysticSwitchCool = 240;
                }
                if (mysticMarblite)
                {
                    player.AddBuff(mod.BuffType("ForGlory"), 180 + (int)(120 * mysticDuration));
                    player.AddBuff(mod.BuffType("ForHonor"), 180 + (int)(120 * mysticDuration));
                }
                if (andioChestplate)
                {
                    player.AddBuff(mod.BuffType("ChestplateSwitch"), 300);
                }
            }

        }
    }
}
