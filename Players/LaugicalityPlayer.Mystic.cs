using System;
using Laugicality.Buffs;
using Laugicality.Projectiles.Mystic.Burst;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Tinq;

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
            MysticObsidiumSwitch = false;

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
            OverflowVelocity = 1f;
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



            if (MysticObsidiumSwitch)
            {
                player.AddBuff(ModContent.BuffType<ObsidiumArmorBuff>(), 6 * 60);
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

                //if (AndioChestguard)
                //{
                //    MysticSpiralBurst += 150;
                //    MysticSwitchCool += 4 * 60;
                //}

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
            Laugicality.MysticaUI.CyclePositions(MysticMode);
        }

        private void Blink()
        {
            var rect = GenerateAngledHitbox(player.Center + (Main.MouseWorld - player.Center).SafeNormalize(Vector2.UnitY) * 10, Main.MouseWorld, 36f, 400f);
            var target = Main.npc.WhereActive(n =>
            {
                return !n.friendly && CheckWithinAngledRectangle(n.Center, rect);
            });

            foreach (NPC npc in target)
            {
                npc.AddBuff(BuffID.OnFire, 2);
            }
        }

        private Vector2[] GenerateAngledHitbox(Vector2 center, Vector2 target, float width, float length)
        {
            var dirTo = Direction(center, target);// (float)Math.Atan2((center.X - target.X), (center.Y - target.Y)) + (float)Math.PI / 2;
            var b1 = center + new Vector2((float)Math.Cos(dirTo - Math.PI / 2), (float)Math.Sin(dirTo - Math.PI / 2)) * width;
            var b2 = b1 + new Vector2((float)Math.Cos(dirTo), (float)Math.Sin(dirTo)) * length;
            var t1 = center + new Vector2((float)Math.Cos(dirTo + Math.PI / 2), (float)Math.Sin(dirTo + Math.PI / 2)) * width;
            var t2 = t1 + new Vector2((float)Math.Cos(dirTo), (float)Math.Sin(dirTo)) * length;

            var bTtheta = dirTo + (float)Math.PI / 2;// Direction(b1, t1);// (float)Math.Atan2((b1.X - t1.X), (b1.Y - t1.Y));

            Vector2[] angles = new Vector2[]{
                b1,
                b2,
                t1, 
                t2,
                new Vector2(length, width * 2)
            };
            return angles;
        }

        private bool CheckWithinAngledRectangle(Vector2 pos, Vector2[] rect)
        {
            if (rect.Length != 5)
                return false;

            int dust = Dust.NewDust(rect[0], 0, 0, DustID.Smoke);
            Main.dust[dust].velocity *= 0;
            dust = Dust.NewDust(rect[1], 0, 0, DustID.Smoke);
            Main.dust[dust].velocity *= 0;
            dust = Dust.NewDust(rect[2], 0, 0, DustID.Fire);
            Main.dust[dust].velocity *= 0;
            /*dust = Dust.NewDust(rect[0] + rect[2] - rect[1], 0, 0, DustID.Smoke);
            Main.dust[dust].velocity *= 0;*/
            dust = Dust.NewDust(rect[3], 0, 0, DustID.Fire);
            Main.dust[dust].velocity *= 0;

            var result = Direction(rect[0], pos) + 
                Direction(rect[1], pos) + 
                Direction(rect[2], pos) + 
                Direction(rect[3], pos);
            result = Distance(rect[0], pos) +
                 Distance(rect[1], pos) +
                 Distance(rect[2], pos) +
                 Distance(rect[3], pos);
            result -= 2 * (float)Math.Sqrt(rect[4].X * rect[4].X + rect[4].Y * rect[4].Y);
            Main.NewText((result).ToString());
            var newResult = Math.Abs(result) < (float)(Math.Sqrt(rect[4].Y * rect[4].X)) / 2 && (Direction(rect[0], pos) >= Direction(rect[0], rect[1])) && (Direction(rect[2], pos) <= Direction(rect[2], rect[3]));
            Main.NewText((newResult).ToString());
            return newResult;
        }

        private float Distance(Vector2 pos1, Vector2 pos2)
        {
            return (float)Math.Sqrt((pos2.Y - pos1.Y) * (pos2.Y - pos1.Y) + (pos2.X - pos1.X) * (pos2.X - pos1.X));
        }

        private float Direction(Vector2 pos1, Vector2 pos2)
        {
            return (float)Math.Atan2((pos2.Y - pos1.Y), (pos2.X - pos1.X));
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

        public bool IsOnOverflow()
        {
            if (MysticMode == 1 && Lux > LuxMax + LuxMaxPermaBoost)
                return true;
            if (MysticMode == 2 && Vis > VisMax + VisMaxPermaBoost)
                return true;
            if (MysticMode == 3 && Mundus > MundusMax + MundusMaxPermaBoost)
                return true;
            return false;
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

        public void AddLux(float amount)
        {
            Lux = Math.Min(Lux + amount, (LuxMax + LuxMaxPermaBoost) * LuxOverflow * GlobalOverflow);
        }

        public void AddVis(float amount)
        {
            Vis = Math.Min(Vis + amount, (VisMax + VisMaxPermaBoost) * VisOverflow * GlobalOverflow);
        }

        public void AddMundus(float amount)
        {
            Mundus = Math.Min(Mundus + amount, (MundusMax + MundusMaxPermaBoost) * MundusOverflow * GlobalOverflow);
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

        public bool MysticObsidiumSwitch { get; set; } = false;

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
        public float OverflowVelocity { get; set; } = 1f;

        #endregion

        #region Overflows

        public int ShroomOverflow { get; set; }

        public int Incineration { get; set; }

        public int Mysticality { get; set; }

        #endregion
    }
}
