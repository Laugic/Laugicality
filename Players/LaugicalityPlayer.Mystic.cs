using System;
using Terraria;

namespace Laugicality
{
    public partial class LaugicalityPlayer
    {
        /// <summary>
        /// Refactor This to be short
        /// </summary>

        private void MysticReset()
        {
            if (UsingMysticItem > 0)
                UsingMysticItem--;
            else
            {
                orionCharge = 0;
            }
            if (mysticSwitchCool > 0)
                mysticSwitchCool -= mysticSwitchCoolRate;
            if (mysticErupting > 0)
                mysticErupting -= 1;
            if (mysticSpiralBurst > 0)
                mysticSpiralBurst -= 1;
            if (mysticSteamSpiralBurst > 0)
                mysticSteamSpiralBurst -= 1;
            MysticCrit = 4;
            MysticDamage = 1f;
            MysticDuration = 1f;
            if (MysticHold > 0)
                MysticHold -= 1;
            if (shroomOverflow > 0)
                shroomOverflow--;
            if (incineration > 0)
                incineration--;

            IllusionDamage = 1f;
            DestructionDamage = 1f;
            ConjurationDamage = 1f;

            mysticSwitchCoolRate = 1;
            mysticBurstDamage = 1f;
            mysticSandBurst = false;
            mysticSteamBurst = false;
            mysticShroomBurst = false;
            mysticMarblite = false;
            mysticEruption = false;
            mysticEruptionBurst = false;
            mysticObsidiumBurst = false;

            if (mysticality > 0)
                mysticality -= 1;
            luxDischargeRate = 1;
            luxOverflow = 1.25f;
            luxAbsorbRate = 1;
            visDischargeRate = 1;
            visOverflow = 1.25f;
            visAbsorbRate = 1;
            mundusDischargeRate = 1;
            mundusOverflow = 1.25f;
            mundusAbsorbRate = 1;
            globalAbsorbRate = .5f;
            globalOverflow = 1f;
            overflowDamage = 1f;

            luxMax = 100;
            visMax = 100;
            mundusMax = 100;

            currentLuxCost = 0;
            currentVisCost = 0;
            currentMundusCost = 0;

            luxUseRate = 1;
            visUseRate = 1;
            mundusUseRate = 1;
            globalPotentiaUseRate = 1;
        }

        public override void PreUpdateBuffs()
        {
            luxMax = 100;
            visMax = 100;
            mundusMax = 100;
        }

        public void MysticSwitch()
        {
            switch(MysticMode)
            {
                case 1: MysticMode = 3;
                    break;
                case 2:
                    MysticMode = 1;
                    break;
                case 3:
                    MysticMode = 2;
                    break;
                default:
                    break;
            }
            if (mysticSwitchCool <= 0 && !mysticBurstDisabled)
            {
                if (mysticShroomBurst)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 2.5f, -6.25f, mod.ProjectileType("ShroomBurst"), (int)(10 * MysticDamage * mysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 5, -5, mod.ProjectileType("ShroomBurst"), (int)(10 * MysticDamage * mysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, -5, -5, mod.ProjectileType("ShroomBurst"), (int)(10 * MysticDamage * mysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, -2.5f, -6.25f, mod.ProjectileType("ShroomBurst"), (int)(10 * MysticDamage * mysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 2.5f / 2, -6.75f, mod.ProjectileType("ShroomBurst"), (int)(10 * MysticDamage * mysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 3.75f, -5.75f, mod.ProjectileType("ShroomBurst"), (int)(10 * MysticDamage * mysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, -3.75f, -5.75f, mod.ProjectileType("ShroomBurst"), (int)(10 * MysticDamage * mysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, -2.5f / 2, -6.75f, mod.ProjectileType("ShroomBurst"), (int)(10 * MysticDamage * mysticBurstDamage), 3, Main.myPlayer);

                    mysticSwitchCool += 1 * 60;
                }
                if (mysticEruption)
                {
                    mysticErupting += 90;
                    mysticSwitchCool += 3 * 60;
                }
                if (magmatic)
                {
                    mysticErupting += 90;
                    mysticSwitchCool += 3 * 60;
                }
                if (mysticSandBurst)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y + 16, 2, 0, mod.ProjectileType("AncientRune"), (int)(12 * MysticDamage * mysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y + 16, -2, 0, mod.ProjectileType("AncientRune"), (int)(12 * MysticDamage * mysticBurstDamage), 3, Main.myPlayer);

                    mysticSwitchCool += 3 * 60;
                }
                if (mysticEruptionBurst)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y + 16, 4, 0, mod.ProjectileType("EruptionBurst"), (int)(12 * MysticDamage * mysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y + 16, -4, 0, mod.ProjectileType("EruptionBurst"), (int)(12 * MysticDamage * mysticBurstDamage), 3, Main.myPlayer);
                    mysticErupting += 45;

                    mysticSwitchCool += 4 * 60;
                }
                if (andioChestguard)
                {
                    mysticSpiralBurst += 150;
                    mysticSwitchCool += 4 * 60;
                }
                if (mysticObsidiumBurst)
                {
                    float mag = 12f;
                    float theta = 0;
                    for (int i = 0; i < 16; i++)
                    {
                        theta += (float)Math.PI / 8;
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, mag * (float)Math.Cos(theta), mag * (float)Math.Sin(theta), mod.ProjectileType("ObsidiumMysticBurst"), (int)(24 * MysticDamage * mysticBurstDamage), 3, Main.myPlayer);
                    }
                    mysticSwitchCool += 4 * 60;
                }
                if (mysticSteamBurst)
                {
                    mysticSteamSpiralBurst += 145;
                    mysticSwitchCool += 4 * 60;
                }
                if (mysticMarblite)
                {
                    player.AddBuff(mod.BuffType("ForGlory"), 180 + (int)(120 * MysticDuration));
                    player.AddBuff(mod.BuffType("ForHonor"), 180 + (int)(120 * MysticDuration));
                }
            }
            Laugicality.instance.mysticaUI.CyclePositions(MysticMode);
        }

        private void PostUpdateMysticBuffs()
        {
            if (andioChestplate)
            {
                if (lux < (luxMax + luxMaxPermaBoost))
                    DestructionDamage += (1 - (lux / (luxMax + luxMaxPermaBoost))) / 5;
                if (vis < (visMax + visMaxPermaBoost))
                    IllusionDamage += (1 - (vis / (visMax + visMaxPermaBoost))) / 5;
                if (mundus < (mundusMax + mundusMaxPermaBoost))
                    ConjurationDamage += (1 - (mundus / (mundusMax + mundusMaxPermaBoost))) / 5;
            }
        }


        #region General Mystic Vars

        public float MysticDamage { get; set; } = 1f;

        public float MysticDuration { get; set; } = 1f;

        public int MysticCrit { get; set; } = 4;

        public int MysticMode { get; set; } = 1;

        public float IllusionDamage { get; set; } = 1f;

        public float DestructionDamage { get; set; } = 1f;

        public float ConjurationDamage { get; set; } = 1f;

        public int MysticHold { get; set; } = 0;

        public int UsingMysticItem { get; set; } = 0;

        #endregion

        //Mystic Bursts
        public bool mysticBurstDisabled = false;
        public float mysticBurstDamage = 1f;
        public int mysticSwitchCool = 0;
        public int mysticSwitchCoolRate = 1;
        public bool mysticSteamBurst = false;
        public bool mysticShroomBurst = false;
        public bool mysticSandBurst = false;
        public bool mysticEruptionBurst = false;
        public bool mysticMarblite = false;
        public bool andioChestplate = false;
        public bool andioChestguard = false;
        public bool midnight = false;
        public int mysticSpiralBurst = 0;
        public int mysticSpiralDelay = 0;
        public int mysticSteamSpiralBurst = 0;
        public int mysticSteamSpiralDelay = 0;
        public bool mysticEruption = false;
        public int mysticErupting = 0;
        public bool magmatic = false;
        public int orionCharge = 0;
        public bool mysticObsidiumBurst = false;

        //Mystica
        public float lux = 100;
        public float luxMax = 100;
        public float luxOverflow = 1.25f;
        public float luxDischargeRate = 1;
        public float luxAbsorbRate = 1;
        public float mundus = 100;
        public float mundusMax = 100;
        public float mundusOverflow = 1.25f;
        public float mundusDischargeRate = 1;
        public float mundusAbsorbRate = 1;
        public float vis = 100;
        public float visMax = 100;
        public float visOverflow = 1.25f;
        public float visDischargeRate = 1;
        public float visAbsorbRate = 1;
        public float globalAbsorbRate = .5f;
        public float luxUseRate = 1f;
        public float visUseRate = 1f;
        public float mundusUseRate = 1f;
        public float globalPotentiaUseRate = 1f;
        public float globalOverflow = 1f;
        public float overflowDamage = 1f;

        public float luxMaxPermaBoost = 0;
        public float visMaxPermaBoost = 0;
        public float mundusMaxPermaBoost = 0;
        public int currentLuxCost = 0;
        public int currentVisCost = 0;
        public int currentMundusCost = 0;

        //Overflows
        public int shroomOverflow = 0;
        public int incineration = 0;

        public int mysticality = 0;
    }
}
