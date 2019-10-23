using System;
using Laugicality.Buffs;
using Laugicality.Projectiles.Mystic.Burst;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality
{
    public sealed partial class LaugicalityPlayer
    {
        /// <summary>
        /// Refactor This to be short
        /// </summary>

        private void MysticReset()
        {
            if (UsingMysticItem > 0)
                UsingMysticItem--;
            else
                OrionCharge = 0;

            if (MysticSwitchCool > 0)
                MysticSwitchCool -= MysticSwitchCoolRate;

            if (MysticErupting > 0)
                MysticErupting -= 1;

            if (MysticSpiralBurst > 0)
                MysticSpiralBurst -= 1;

            if (MysticSteamSpiralBurst > 0)
                MysticSteamSpiralBurst -= 1;

            MysticCrit = 4;
            MysticDamage = 1f;
            MysticDuration = 1f;

            if (MysticHold > 0)
                MysticHold -= 1;

            if (ShroomOverflow > 0)
                ShroomOverflow--;

            if (Incineration > 0)
                Incineration--;

            IllusionDamage = 1f;
            DestructionDamage = 1f;
            ConjurationDamage = 1f;

            MysticSwitchCoolRate = 1;
            MysticBurstDamage = 1f;
            MysticSandBurst = false;
            MysticSteamBurst = false;
            MysticShroomBurst = false;
            MysticMarblite = false;
            MysticEruption = false;
            MysticEruptionBurst = false;
            MysticObsidiumBurst = false;

            if (Mysticality > 0)
                Mysticality -= 1;

            LuxDischargeRate = 1;
            LuxOverflow = 1.25f;
            LuxAbsorbRate = 1;
            VisDischargeRate = 1;
            VisOverflow = 1.25f;
            VisAbsorbRate = 1;
            MundusDischargeRate = 1;
            MundusOverflow = 1.25f;
            MundusAbsorbRate = 1;
            GlobalAbsorbRate = .5f;
            GlobalOverflow = 1f;
            OverflowDamage = 1f;
            AntiflowDamage = 1f;

            LuxMax = 100;
            VisMax = 100;
            MundusMax = 100;

            LuxUseRate = 1;
            VisUseRate = 1;
            MundusUseRate = 1;
            GlobalPotentiaUseRate = 1;

            if (SporeShard > 0)
                SporeShard -= 1;

            LuxRegen = 0;
            VisRegen = 0;
            MundusRegen = 0;

            LuxUnuseRegen = .01f;
            VisUnuseRegen = .01f;
            MundusUnuseRegen = .01f;
        }

        public override void PreUpdateBuffs()
        {
            LuxMax = 100;
            VisMax = 100;
            MundusMax = 100;
        }

        private void PotentiaRegen()
        {
            if (Lux + LuxRegen <= LuxMax + LuxMaxPermaBoost)
                Lux += LuxRegen;
            if (Vis + VisRegen <= VisMax + VisMaxPermaBoost)
                Vis += VisRegen;
            if (Mundus + MundusRegen <= MundusMax + MundusMaxPermaBoost)
                Mundus += MundusRegen;

            if (Lux + LuxUnuseRegen <= LuxMax + LuxMaxPermaBoost && MysticMode != 1)
                Lux += LuxUnuseRegen;
            if (Vis + VisUnuseRegen <= VisMax + VisMaxPermaBoost && MysticMode != 2)
                Vis += VisUnuseRegen;
            if (Mundus + MundusUnuseRegen <= MundusMax + MundusMaxPermaBoost && MysticMode != 3)
                Mundus += MundusUnuseRegen;

            if(player.statLife < 1)
            {
                Lux = LuxMax + LuxMaxPermaBoost;
                Vis = VisMax + VisMaxPermaBoost;
                Mundus = MundusMax + MundusMaxPermaBoost;
            }
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
            if (MysticSwitchCool <= 0 && !MysticBurstDisabled)
            {
                if (MysticShroomBurst)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 2.5f, -6.25f, ModContent.ProjectileType<ShroomBurst>(), (int)(10 * MysticDamage * MysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 5, -5, ModContent.ProjectileType<ShroomBurst>(), (int)(10 * MysticDamage * MysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, -5, -5, ModContent.ProjectileType<ShroomBurst>(), (int)(10 * MysticDamage * MysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, -2.5f, -6.25f, ModContent.ProjectileType<ShroomBurst>(), (int)(10 * MysticDamage * MysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 2.5f / 2, -6.75f, ModContent.ProjectileType<ShroomBurst>(), (int)(10 * MysticDamage * MysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 3.75f, -5.75f, ModContent.ProjectileType<ShroomBurst>(), (int)(10 * MysticDamage * MysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, -3.75f, -5.75f, ModContent.ProjectileType<ShroomBurst>(), (int)(10 * MysticDamage * MysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, -2.5f / 2, -6.75f, ModContent.ProjectileType<ShroomBurst>(), (int)(10 * MysticDamage * MysticBurstDamage), 3, Main.myPlayer);

                    MysticSwitchCool += 1 * 60;
                }

                if (MysticEruption)
                {
                    MysticErupting += 90;
                    MysticSwitchCool += 3 * 60;
                }

                if (Magmatic)
                {
                    MysticErupting += 90;
                    MysticSwitchCool += 3 * 60;
                }

                if (MysticSandBurst)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y + 16, 2, 0, ModContent.ProjectileType<AncientRune>(), (int)(12 * MysticDamage * MysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y + 16, -2, 0, ModContent.ProjectileType<AncientRune>(), (int)(12 * MysticDamage * MysticBurstDamage), 3, Main.myPlayer);

                    MysticSwitchCool += 3 * 60;
                }

                if (MysticEruptionBurst)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y + 16, 4, 0, ModContent.ProjectileType<EruptionBurst>(), (int)(12 * MysticDamage * MysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y + 16, -4, 0, ModContent.ProjectileType<EruptionBurst>(), (int)(12 * MysticDamage * MysticBurstDamage), 3, Main.myPlayer);
                    MysticErupting += 45;

                    MysticSwitchCool += 4 * 60;
                }

                if (AndioChestguard)
                {
                    MysticSpiralBurst += 150;
                    MysticSwitchCool += 4 * 60;
                }

                if (MysticObsidiumBurst)
                {
                    float mag = 12f;
                    float theta = 0;

                    for (int i = 0; i < 16; i++)
                    {
                        theta += (float)Math.PI / 8;
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, mag * (float)Math.Cos(theta), mag * (float)Math.Sin(theta), ModContent.ProjectileType<ObsidiumMysticBurst>(), (int)(24 * MysticDamage * MysticBurstDamage), 3, Main.myPlayer);
                    }

                    MysticSwitchCool += 4 * 60;
                }

                if (MysticSteamBurst)
                {
                    MysticSteamSpiralBurst += 145;
                    MysticSwitchCool += 4 * 60;
                }

                if (MysticMarblite)
                {
                    player.AddBuff(ModContent.BuffType<ForGlory>(), 180 + (int)(120 * MysticDuration));
                    player.AddBuff(ModContent.BuffType<ForHonor>(), 180 + (int)(120 * MysticDuration));
                }
                if(MysticSwitchCool > 0)
                    PostBurstEffects();
            }
            Laugicality.Instance.MysticaUI.CyclePositions(MysticMode);
        }

        private void PostBurstEffects()
        {
            if (PrismVeil)
            {
                if (MysticSwitchCool < 3 * 60 * MysticSwitchCoolRate)
                    MysticSwitchCool = 3 * 60 * MysticSwitchCoolRate;
                player.immune = true;
                player.immuneTime = 60;
            }
        }

        private void PostUpdateMysticBuffs()
        {
            PotentiaRegen();

            if (AndioChestplate)
            {
                if (Lux < (LuxMax + LuxMaxPermaBoost))
                    DestructionDamage += (1 - (Lux / (LuxMax + LuxMaxPermaBoost))) / 5;

                if (Vis < (VisMax + VisMaxPermaBoost))
                    IllusionDamage += (1 - (Vis / (VisMax + VisMaxPermaBoost))) / 5;

                if (Mundus < (MundusMax + MundusMaxPermaBoost))
                    ConjurationDamage += (1 - (Mundus / (MundusMax + MundusMaxPermaBoost))) / 5;
            }
        }


        public int SporeShard { get; set; } = 0;

        public float AntiflowDamage { get; set; } = 1f;

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

        public float LuxRegen { get; set; } = 0;

        public float VisRegen { get; set; } = 0;

        public float MundusRegen { get; set; } = 0;

        public float LuxUnuseRegen { get; set; } = .01f;

        public float VisUnuseRegen { get; set; } = .01f;

        public float MundusUnuseRegen { get; set; } = .01f;

        #endregion

        #region Mystic Bursts

        public bool MysticBurstDisabled { get; set; } = false;

        public float MysticBurstDamage { get; set; } = 1f;

        public int MysticSwitchCool { get; set; } = 0;

        public int MysticSwitchCoolRate { get; set; } = 1;

        public bool MysticSteamBurst { get; set; } = false;

        public bool MysticShroomBurst { get; set; } = false;

        public bool MysticSandBurst { get; set; } = false;

        public bool MysticEruptionBurst { get; set; } = false;

        public bool MysticMarblite { get; set; } = false;

        public bool AndioChestplate { get; set; } = false;

        public bool AndioChestguard { get; set; } = false;

        public bool Midnight { get; set; } = false;

        public int MysticSpiralBurst { get; set; } = 0;

        public int MysticSpiralDelay { get; set; } = 0;

        public int MysticSteamSpiralBurst { get; set; } = 0;

        public int MysticSteamSpiralDelay { get; set; } = 0;

        public bool MysticEruption { get; set; } = false;

        public int MysticErupting { get; set; } = 0;

        public bool Magmatic { get; set; } = false;

        public int OrionCharge { get; set; } = 0;

        public bool MysticObsidiumBurst { get; set; } = false;

        #endregion

        #region Mystica

        public float Lux { get; set; } = 100;
        public float LuxMax { get; set; } = 100;
        public float LuxOverflow { get; set; } = 1.25f;
        public float LuxDischargeRate { get; set; } = 1;
        public float LuxAbsorbRate { get; set; } = 1;
        public float LuxUseRate { get; set; } = 1f;
        public float LuxMaxPermaBoost { get; set; } = 0;
        public int CurrentLuxCost { get; set; }

        public float Mundus { get; set; } = 100;
        public float MundusMax { get; set; } = 100;
        public float MundusOverflow { get; set; } = 1.25f;
        public float MundusDischargeRate { get; set; } = 1;
        public float MundusAbsorbRate { get; set; } = 1;
        public float MundusUseRate { get; set; } = 1f;
        public float MundusMaxPermaBoost { get; set; } = 0;
        public int CurrentMundusCost { get; set; } = 0;

        public float Vis { get; set; } = 100;
        public float VisMax { get; set; } = 100;
        public float VisOverflow { get; set; } = 1.25f;
        public float VisDischargeRate { get; set; } = 1;
        public float VisAbsorbRate { get; set; } = 1;
        public float VisUseRate { get; set; } = 1f;
        public float VisMaxPermaBoost { get; set; } = 0;
        public int CurrentVisCost { get; set; } = 0;

        public float GlobalAbsorbRate { get; set; } = .5f;
        public float GlobalPotentiaUseRate { get; set; } = 1f;
        public float GlobalOverflow { get; set; } = 1f;
        public float OverflowDamage { get; set; } = 1f;

        #endregion

        #region Overflows

        public int ShroomOverflow { get; set; }

        public int Incineration { get; set; }

        public int Mysticality { get; set; }

        #endregion
    }
}
