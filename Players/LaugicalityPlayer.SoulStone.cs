using Laugicality.Buffs;
using Laugicality.Projectiles;
using Laugicality.Projectiles.Mystic.Conjuration;
using Laugicality.Projectiles.SoulStone;
using Laugicality.SoulStones;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Laugicality
{
    public sealed partial class LaugicalityPlayer
    {
        private const int HONEY_BASE_LIFE_REGEN = 2;
        public const string 
            FOCUS_NAME_CAPACITY = "Capacity",
            FOCUS_NAME_VITALITY = "Vitality",
            FOCUS_NAME_TENACITY = "Tenacity",
            FOCUS_NAME_MOBILITY = "Mobility",
            FOCUS_NAME_UTILITY = "Utility",
            FOCUS_NAME_FEROCITY = "Ferocity";

        internal void ResetSoulStoneEffects()
        {
            KingSlimeStomp = false;
            HoneyRegenMultiplier = 1;
            SharkronEffect = false;
            EvilBossEffect = false;
            SkeletronEffect = false;
            WallOfFleshEffect = false;
            TwinsEffect = false;
            DestroyerEffect = false;
            SkeletronPrimeEffect = false;
            MoonLordEffect = false;
            Lovestruck = false;
            SteamTrainEffect = false;
            GolemEffect = false;
            DestroyerCooldown = false;
            HypothemaEffect = false;
            QueenBeeEffect = false;
            FishronEffect = false;
            EtheriaEffect = false;
            CancelNoKnockback = false;

            if (!player.HasBuff(Laugicality.Instance.BuffType<MoonLordSoulCooldownBuff>()))
                MoonLordLifeMult = 1f;

            AnDioCapacityEffect = false;
            DestroyerCapacityEffect = false;
            if (DungeonGuardianCounter > 0)
                DungeonGuardianCounter--;

            CapacityCurse1 = false;
            CapacityCurse2 = false;
            MobilityCurse2 = false;
            VitalityCurse2 = false;
            TenacityCurse2 = false;
            CapacityCurse3 = false;
            UtilityCurse3 = false;
            VitalityCurse3 = false;
            VitalityCurse4 = false;
            CapacityCurse4 = false;
        }

        internal void UpdateSoulStoneLifeRegen()
        {
            if (player.honey)
                player.lifeRegen += HONEY_BASE_LIFE_REGEN * HoneyRegenMultiplier - HONEY_BASE_LIFE_REGEN;
            if(!player.immune)
            {
                CapacityCurse4Applied = false;
                MoonLordEffectApplied = false;
            }
            if (FocusName == FOCUS_NAME_CAPACITY && SkeletronPrimeEffect && player.ownedProjectileCounts[mod.ProjectileType<FriendlyDungeonGuardianPrime>()] <= 0 && player.statLife <= player.statLifeMax2 / 2)
            {
                Projectile.NewProjectile(player.Center, new Vector2(0, 0), mod.ProjectileType<FriendlyDungeonGuardianPrime>(), 99, 4, player.whoAmI);
            }
            if (FocusName == FOCUS_NAME_CAPACITY && GolemEffect && player.ownedProjectileCounts[mod.ProjectileType<FriendlyGolemProj>()] <= 0 && player.statLife <= player.statLifeMax2 / 2)
            {
                Projectile.NewProjectile(player.Center, new Vector2(0, 0), mod.ProjectileType<FriendlyGolemProj>(), 0, 4, player.whoAmI);
            }
            if (FocusName == FOCUS_NAME_CAPACITY && MoonLordEffect && player.ownedProjectileCounts[mod.ProjectileType<FriendlyGolemProj>()] <= 0 && player.statLife <= player.statLifeMax2 / 2)
            {
                Projectile.NewProjectile(player.Center, new Vector2(0, 0), mod.ProjectileType<FriendlyTrueEyeProj>(), (int)(150 * GetGlobalDamage()), 4, player.whoAmI);
            }
        }

        internal bool SoulStonePreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if(CancelNoKnockback)
                player.noKnockback = false;

            if (FocusName == FOCUS_NAME_CAPACITY)
                CapacityPreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);

            if (SkeletronEffect && FocusName == FOCUS_NAME_MOBILITY && Main.rand.Next(25) == 0)
            {
                player.immune = true;
                player.immuneTime = 2 * 60;
                return false;
            }

            if (MoonLordEffect && FocusName == FOCUS_NAME_MOBILITY)
            {
                int mobChance = 50;
                mobChance -= (int)(Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y));
                if (mobChance < 4)
                    mobChance = 4;
                if (Main.rand.Next(mobChance) == 0)
                {
                    player.immune = true;
                    player.immuneTime = 2 * 60;
                    return false;
                }
            }

            if (DestroyerEffect && !DestroyerCooldown && damage >= 50 && damage > player.statLife)
            {
                player.AddBuff(mod.BuffType<DestroyerSoulCooldownBuff>(), 90 * Constants.TICKS_PER_SECONDS);
                player.immune = true;
                player.immuneTime = 2 * 60;
                return false;
            }

            if(SteamTrainEffect && !player.HasBuff(Laugicality.Instance.BuffType<SteamTrainSoulCooldownBuff>()) && FocusName == FOCUS_NAME_VITALITY)
            {
                if (player.statLife < player.statLifeMax2)
                {
                    player.statLife = player.statLifeMax2;
                    player.AddBuff(mod.BuffType<SteamTrainSoulCooldownBuff>(), 150 * Constants.TICKS_PER_SECONDS);
                    player.immune = true;
                    player.immuneTime = 2 * 60;
                    return false;
                }
            }

            if(MoonLordEffect && FocusName == FOCUS_NAME_VITALITY && player.statLifeMax2 > 100 && damage >= player.statLife)
            {
                MoonLordLifeMult *= .5f;
                player.statLifeMax2 = (int)(MoonLordLifeMult * player.statLifeMax2);
                player.statLife = player.statLifeMax2;
                player.AddBuff(mod.BuffType<MoonLordSoulCooldownBuff>(), 90 * Constants.TICKS_PER_SECONDS);
                player.immune = true;
                player.immuneTime = 2 * 60;
                return false;
            }
            if (MoonLordEffect && !player.HasBuff(Laugicality.Instance.BuffType<MoonLordSoulCooldownBuff>()) && FocusName == FOCUS_NAME_TENACITY)
            {
                player.AddBuff(mod.BuffType<MoonLordSoulCooldownBuff>(), 30 * Constants.TICKS_PER_SECONDS);
                player.immune = true;
                player.immuneTime = 2 * 60;
                return false;
            }
            return true;
        }

        internal void CapacityPreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (CapacityCurse1)
                damage += 5;
            if(WallOfFleshEffect && !player.HasBuff(Laugicality.Instance.BuffType<WallOfFleshEffectCooldownBuff>()) && damage > 1)
            {
                damage = 1;
                player.AddBuff(mod.BuffType<WallOfFleshEffectCooldownBuff>(), 120 * Constants.TICKS_PER_SECONDS);
            }
            if (EtheriaEffect)
            {
                player.AddBuff(mod.BuffType<EtherialEffectCooldownBuff>(), 20 * 60, false);
            }
        }

        internal void SoulStonePostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if(MobilityCurse2)
                player.AddBuff(mod.BuffType<MobilityCurseBuff>(), 4 * Constants.TICKS_PER_SECONDS);

            if (QueenBeeEffect && FocusName == FOCUS_NAME_TENACITY)
            {
                if(player.HasBuff(BuffID.Poisoned))
                {
                    player.buffImmune[BuffID.Poisoned] = true;
                    player.statLife += 10;
                }
                if (player.HasBuff(BuffID.Venom))
                {
                    player.buffImmune[BuffID.Venom] = true;
                    player.statLife += 10;
                }
            }
            if (DefenseCounter > 0)
                DefenseCounter = 0;
            if (FocusName == FOCUS_NAME_CAPACITY)
                CapacityPostHurt(pvp, quiet, damage, hitDirection, crit);
        }

        internal void CapacityPostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (CapacityCurse2)
                player.AddBuff(mod.BuffType<CapacityCurseBuff>(), 10 * Constants.TICKS_PER_SECONDS);
            if(CapacityCurse4 && !CapacityCurse4Applied && player.immune)
            {
                CapacityCurse4Applied = true;
                player.immuneTime /= 2;
            }
            if(MoonLordEffect && !MoonLordEffectApplied && player.immune)
            {
                MoonLordEffectApplied = true;
                player.immuneTime *= 2;
            }
            if (QueenBeeEffect && player.ownedProjectileCounts[mod.ProjectileType<CapacityThornsProj>()] <= 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    Projectile.NewProjectile(player.Center, new Vector2(0, 0), mod.ProjectileType<CapacityThornsProj>(), (int)(15 * GetGlobalDamage()), 5f, player.whoAmI, (float)(Math.PI / 4) * i);
                }
            }
            if (TwinsEffect && player.ownedProjectileCounts[mod.ProjectileType<ShadowDoubleProj>()] <= 0)
            {
                Projectile.NewProjectile(player.Center, new Vector2(0, 0), mod.ProjectileType<ShadowDoubleProj>(), (int)(60 * GetGlobalDamage()), 0, player.whoAmI);
            }
            if (DestroyerCapacityEffect && player.statLife < player.statLifeMax2 * .66)
            {
                Projectile.NewProjectile(player.Center, new Vector2(0, 0), mod.ProjectileType<FriendlyProbeProj>(), (int)(60 * GetGlobalDamage()), 4f, player.whoAmI);
            }
            if (FishronEffect)
            {
                int rand = Main.rand.Next(5, 9);
                for (int i = 0; i < rand; i++)
                {
                    float theta = -Main.rand.NextFloat() * (float)Math.PI;
                    Projectile.NewProjectile(player.Center, new Vector2((float)Math.Cos(theta) * 6, (float)Math.Sin(theta) * 6), ProjectileID.MiniSharkron, (int)(75 * GetGlobalDamage()), 4f, player.whoAmI);
                }
            }
            if (EtheriaEffect)
            {
                player.AddBuff(mod.BuffType<EtherialEffectCooldownBuff>(), 20 * 60, false);
            }
        }

        internal void SoulStoneBadLifeRegen()
        {
            if (HypothemaEffect && player.lifeRegen < 0 && (FocusName == FOCUS_NAME_VITALITY || FocusName == FOCUS_NAME_TENACITY))
                player.statDefense += 8;
            if(UtilityCurse3 && player.lifeRegen < 0)
            {
                player.lifeRegen -= player.lifeRegen / 2;
            }
            if (VitalityCurse2 && player.lifeRegen < 0)
            {
                player.lifeRegen -= 2;
            }
            if (VitalityCurse3 && player.statLife >= player.statLifeMax2 / 2)
            {
                player.lifeRegen = 0;
            }
            if (VitalityCurse4)
            {
                if (player.statLifeMax2 > player.statLifeMax)
                    player.statLifeMax2 = player.statLifeMax;
            }
            if (EvilBossEffect && FocusName == FOCUS_NAME_VITALITY)
            {
                if (player.lifeRegen < 0)
                    player.lifeRegen = player.lifeRegen >= -3 ? (player.lifeRegen + 2) : -1;
            }
            if (MoonLordEffect && FocusName == FOCUS_NAME_UTILITY)
            {
                if (player.lifeRegen < 0)
                    player.lifeRegen = 0;
            }
        }

        internal void SoulStoneHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            if (FocusName == FOCUS_NAME_CAPACITY)
                CapacityHitByNPC(npc, ref damage, ref crit);
            if (SteamTrainEffect && !player.HasBuff(Laugicality.Instance.BuffType<SteamTrainSoulCooldownBuff>()) && FocusName == FOCUS_NAME_TENACITY)
            {
                player.AddBuff(mod.BuffType<SteamTrainSoulCooldownBuff>(), 90 * Constants.TICKS_PER_SECONDS);
                player.immune = true;
                player.immuneTime = 2 * 60;
            }

            if (EvilBossEffect && !player.HasBuff(Laugicality.Instance.BuffType<EvilBossCooldownBuff>()) && FocusName == FOCUS_NAME_TENACITY)
            {
                player.AddBuff(mod.BuffType<SteamTrainSoulCooldownBuff>(), 120 * Constants.TICKS_PER_SECONDS);
                player.immune = true;
                player.immuneTime = 2 * 60;
            }

            if(KingSlimeStomp && player.velocity.Y > 4)
            {
                player.ApplyDamageToNPC(npc, player.statDefense + damage + 4, 4f, 0, false);
            }
        }

        internal void CapacityHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            if(player.statLife > player.statLifeMax2 / 2 && CapacityCurse3)
            {
                damage = (int)(damage * 1.5);
            }
            if(!npc.noGravity && SharkronEffect)
            {
                npc.velocity.Y = -15;
            }
            if(DungeonGuardianCounter <= 0 && SkeletronEffect)
            {
                if(npc.boss)
                    DungeonGuardianCounter = 10 * 60;
                else
                    DungeonGuardianCounter = 1 * 60;

                float theta = Main.rand.NextFloat() * 2 * (float)Math.PI;
                float mag = 700;
                Projectile.NewProjectile(player.Center + new Vector2((float)(Math.Cos(theta) * mag), (float)(Math.Sin(theta) * mag)), new Vector2(0, 0), mod.ProjectileType<FriendlyDungeonGuardian>(), 999, 5f, player.whoAmI, npc.whoAmI);
            }
        }

        public int HoneyRegenMultiplier { get; set; }
        public int Counter { get; set; }
        public int DungeonGuardianCounter { get; set; }
        public bool CancelNoKnockback { get; set; }

        public bool KingSlimeStomp { get; set; }
        public bool SharkronEffect { get; set; }
        public bool EvilBossEffect { get; set; }
        public bool HypothemaEffect { get; set; }
        public bool QueenBeeEffect { get; set; }
        public bool SkeletronEffect { get; set; }
        public bool WallOfFleshEffect { get; set; }
        public bool TwinsEffect { get; set; }
        public bool DestroyerEffect { get; set; }
        public bool SkeletronPrimeEffect { get; set; }
        public bool DestroyerCooldown { get; set; }
        public bool Lovestruck { get; set; }
        public int SlybertronCounter { get; set; }
        public bool SteamTrainEffect { get; set; }
        public float GolemBoost { get; set; }
        public bool GolemEffect { get; set; }
        public float MoonLordLifeMult { get; set; }
        public float DefenseCounter { get; set; }
        public bool FishronEffect { get; set; }
        public bool EtheriaEffect { get; set; }
        public bool MoonLordEffect { get; set; }
        public bool MoonLordEffectApplied { get; set; }
        public int AbilityCount { get; set; } = 0;

        public bool AnDioCapacityEffect { get; set; }
        public bool DestroyerCapacityEffect { get; set; }


        public bool CapacityCurse1 { get; set; }
        public bool CapacityCurse2 { get; set; }
        public bool MobilityCurse2 { get; set; }
        public bool VitalityCurse2 { get; set; }
        public bool TenacityCurse2 { get; set; }
        public bool CapacityCurse3 { get; set; }
        public bool UtilityCurse3 { get; set; }
        public bool VitalityCurse3 { get; set; }
        public bool VitalityCurse4 { get; set; }
        public bool CapacityCurse4 { get; set; }
        public bool CapacityCurse4Applied { get; set; }

        public string FocusName { get; set; }
    }
}
