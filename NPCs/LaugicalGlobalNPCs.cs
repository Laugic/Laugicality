using System;
using System.Collections.Generic;
using Laugicality.Buffs;
using Laugicality.Dusts;
using Laugicality.Items.Consumables;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Items.Weapons.Mystic;
using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Laugicality.NPCs.Obsidium;
using Laugicality.Projectiles.Mystic.Conjuration;
using Laugicality.Projectiles.Plague;
using Laugicality.Projectiles.Ranged;
using Bubble = Laugicality.Projectiles.Plague.Bubble;
using Laugicality.Items.Consumables.Buffs;
using Laugicality.Projectiles.NPCProj;
using Laugicality.Items.Equipables;
using Laugicality.Items.Weapons.Range;
using Laugicality.Projectiles.Mystic.Illusion;
using WebmilioCommons.Time;
using Laugicality.Projectiles.Mystic.Misc;

namespace Laugicality.NPCs
{
    public partial class LaugicalGlobalNPCs : GlobalNPC
    {
        public static int JUDGEMENT_DIST = 300;

        public bool eFied = false;
        public bool mFied = false;//Mystified
        public bool hermes = false;
        public float mysticDamage = 1f;
        public int mysticCrit = 4;
        public bool ethSpawn = false;
        public bool lovestruck = false;
        public bool frigid = false;
        public bool bubbly = false;
        public bool dawn = false;
        public bool trueDawn = false;
        private int _dmg = 0;
        public int plays = 0;
        public int dmg2 = 0;
        public static int zTime = 0;
        public int zTimeInstanced = 0;
        public bool zImmune = false;
        public float xTemp = 0;
        public float yTemp = 0;
        public bool invin = false;
        public bool spored = false;
        public bool furious = false;
        public bool slimed = false;
        public bool frostbite = false;
        public bool steamified = false;
        public bool incineration = false;
        public float damageMult = 1f;
        public int attacker = -1;
        public float DebuffDamageMult { get; set; } = 1f;
        public int JunglePlagueDuration { get; set; } = 0;
        public int NumSeeds { get; set; } = 0;
        public int HitDelay { get; set; } = 0;
        public bool JunglePlague { get; set; } = false;
        public bool Fertile { get; set; } = false;
        public bool AerialWeakness { get; set; } = false;
        public bool TimeDilation { get; set; } = false;
        public bool Refracting { get; set; } = false;
        public bool DeathMarked { get; set; } = false;
        public bool Sandy { get; set; } = false;
        public bool Brittle { get; set; } = false;
        public bool Slushie { get; set; } = false;
        public bool Pollinated { get; set; } = false;
        public List<int> ItemTypesHitBy { get; set; }
        public List<int> ProjectileTypesHitBy { get; set; }

        public override void SetDefaults(NPC npc)
        {
            incineration = false;
            steamified = false;
            trueDawn = false;
            dawn = false;
            bubbly = false;
            frostbite = false;
            slimed = false;
            furious = false;
            spored = false;
            plays = 0;
            _dmg = 0;
            invin = npc.dontTakeDamage;
            dmg2 = npc.damage;
            damageMult = npc.takenDamageMultiplier;
            HitDelay = 0;
            ItemTypesHitBy = new List<int>();
            ProjectileTypesHitBy = new List<int>();
            if (LaugicalityVars.zNPCs.Contains(npc.type))
            {
                zImmune = true;
            }
        }

        public override void ResetEffects(NPC npc)
        {
            incineration = false;
            steamified = false;
            trueDawn = false;
            dawn = false;
            bubbly = false;
            frostbite = false;
            slimed = false;
            furious = false;
            spored = false;
            eFied = false;
            mFied = false;
            hermes = false;
            lovestruck = false;
            frigid = false;
            mysticCrit = 4;
            JunglePlague = false;
            AerialWeakness = false;
            if (!Fertile)
                NumSeeds = 0;
            Fertile = false;
            Refracting = false;
            DeathMarked = false;
            Sandy = false;
            Brittle = false;
            Slushie = false;
            Pollinated = false;

            npc.takenDamageMultiplier = damageMult;
            if (zTimeInstanced < zTime)
                zTimeInstanced = zTime;

            if (zTime > 0)
                zTime--;

            if (zTimeInstanced > 0)
                zTimeInstanced--;

            if (JunglePlagueDuration > 0)
                JunglePlagueDuration--;
        }

        public override void ScaleExpertStats(NPC npc, int numPlayers, float bossLifeScale)
        {
            plays = numPlayers;
            dmg2 = npc.damage;
        }

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (LaugicalityPlayer.Get(spawnInfo.player).zoneObsidium)
            {
                if (Main.player[Main.myPlayer].ZoneOverworldHeight || Main.player[Main.myPlayer].ZoneSkyHeight)
                {
                    pool.Add(ModContent.NPCType<LycorisSlime>(), 0.25f);
                    return;
                }
                pool.Clear();
                float spawnMod = .25f;
                if (!Main.hardMode)
                {
                    //pool.Add(ModContent.NPCType<ObsidiumDriller>(), 0.05f * spawnMod);
                    pool.Add(NPCID.Skeleton, 0.25f * spawnMod);
                    pool.Add(ModContent.NPCType<LycorisSlime>(), 0.25f);
                    pool.Add(NPCID.MotherSlime, 0.2f * spawnMod);
                    pool.Add(NPCID.Hellbat, 0.2f * spawnMod);

                    if (LaugicalityWorld.downedRagnar)
                    {
                        pool.Add(ModContent.NPCType<MagmatipedeHead>(), 0.05f * spawnMod);
                        //pool.Add(ModContent.NPCType<ObsidiumSkull>(), 0.10f * spawnMod);
                        //pool.Add(ModContent.NPCType<MagmaCaster>(), 0.30f * spawnMod);
                    }
                }
                else
                {
                    //pool.Add(ModContent.NPCType<MoltenSlime>(), 0.2f * spawnMod);
                    pool.Add(ModContent.NPCType<MoltiochHead>(), 0.015f * spawnMod);
                    pool.Add(ModContent.NPCType<MoltenSoul>(), 0.015f * spawnMod);
                    pool.Add(NPCID.SkeletonArcher, 0.25f * spawnMod);
                    pool.Add(NPCID.GiantBat, 0.25f * spawnMod);
                    //pool.Add(NPCID.Giant, 0.25f * spawnMod);
                    if (LaugicalityWorld.downedRagnar)
                    {
                        pool.Add(ModContent.NPCType<MagmatipedeHead>(), 0.015f * spawnMod);
                        //pool.Add(ModContent.NPCType<ObsidiumSkull>(), 0.05f * spawnMod);
                        //pool.Add(ModContent.NPCType<MagmaCaster>(), 0.20f * spawnMod);
                        pool.Add(ModContent.NPCType<LavaTitan>(), 0.01f * spawnMod);
                    }
                }
            }
            return;
        }

        public override void GetChat(NPC npc, ref string chat)
        {
            if (npc.type == NPCID.ScorpionBlack && LaugicalityWorld.downedEtheria)
                chat = "Why hello there.";
            base.GetChat(npc, ref chat);
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (slimed)
            {
                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= (int)(2);
                if (damage < 2)
                {
                    damage = (2);
                }
            }
            if (furious)
            {
                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= (int)(8);
                if (damage < 8)
                {
                    damage = (8);
                }
            }
            if (incineration)
            {
                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= 8;
                if (damage < 8)
                    damage = 8;
            }
            if (Fertile)
            {
                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= NumSeeds;
                if (damage < NumSeeds)
                    damage = NumSeeds;
            }

            if (hermes)
            {
                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= (int)(4);
                if (damage < 4)
                {
                    damage = (4);
                }
            }

            if (frostbite)
            {
                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= (int)(320);
                if (damage < 320)
                {
                    damage = (320);
                }
            }
            if (steamified)
            {
                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= (int)(80);
                if (damage < 80)
                {
                    damage = (80);
                }
            }
            if (npc.boss == false)
            {
                if (frigid)
                {
                    npc.velocity.X *= 0;
                    npc.velocity.Y *= 0;
                }
            }
            if (bubbly)
            {
                if (Main.rand.Next(1 * 60) == 0 && Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (-1 + 2 * Main.rand.Next(2)) * 4, Main.rand.Next(-5, 2), ModContent.ProjectileType<Bubble>(), 20, 3f, Main.myPlayer);
            }
            if (npc.HasBuff(ModContent.BuffType<DepthBubbles>()))
            {
                if (Main.rand.Next(1 * 60) == 0 && Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (-1 + 2 * Main.rand.Next(2)) * 4, Main.rand.Next(-5, 2), ModContent.ProjectileType<PoseidonConjuration2>(), Math.Max(20, Math.Min(npc.defense, 80)), 3f, Main.myPlayer);
            }
            if (dawn)
            {
                if (Main.rand.Next(1 * 60) == 0 && Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (-1 + 2 * Main.rand.Next(2)) * 4, Main.rand.Next(-5, 2), ModContent.ProjectileType<GoldenBubble>(), 20, 3f, Main.myPlayer);
            }
            if (trueDawn)
            {
                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= (int)(24);
                if (damage < 24)
                {
                    damage = (24);
                }
                if (Main.rand.Next(1 * 60) == 0 && Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (-1 + 2 * Main.rand.Next(2)) * 4, Main.rand.Next(-5, 2), ModContent.ProjectileType<TrueDawnSpark>(), 40, 3f, Main.myPlayer);
            }
            if (npc.HasBuff(ModContent.BuffType<InfernalBuff>()))
            {
                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegenExpectedLossPerSecond = (int)(Math.Max(Math.Min(npc.defense, 80) + 4, 4));
                npc.lifeRegen -= (int)(Math.Max(Math.Min(npc.defense, 80) + 4, 4));
                if (damage < (int)(Math.Max(Math.Min(npc.defense, 80) + 4, 4)))
                    damage = (int)(Math.Max(Math.Min(npc.defense, 80) + 4, 4));
            }
            if (JunglePlague)
            {
                if (Main.rand.Next(1 * 60) == 0 && Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (-1 + 2 * Main.rand.Next(2)) * 4, Main.rand.Next(-5, 2), ModContent.ProjectileType<JunglePlagueSpore>(), 75, 3f, Main.myPlayer);
            }
            if (npc.HasBuff(ModContent.BuffType<TimeDilation>()))
            {
                if (Main.rand.Next(8) == 0)
                    Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<CogDust>(), -4 + Main.rand.NextFloat() * 4, -4 + Main.rand.NextFloat() * 4, 100, default(Color), 3.5f);
            }
            if (npc.HasBuff(ModContent.BuffType<EerinessBuff>()))
            {
                if (Main.rand.Next(8) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 16, -4 + Main.rand.NextFloat() * 4, -4 + Main.rand.NextFloat() * 4, 100, Color.CornflowerBlue, 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].noLight = true;
                }
                    
            }
            if (Sandy)
            {
                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= (int)(npc.velocity.Length() / 2);
                if (damage < (int)(npc.velocity.Length() / 2))
                {
                    damage = ((int)(npc.velocity.Length() / 2));
                }
                if (Main.rand.Next(1 * 60) == 0 && Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (-1 + 2 * Main.rand.Next(2)) * 4, Main.rand.Next(-5, 2), ModContent.ProjectileType<TrueDawnSpark>(), 40, 3f, Main.myPlayer);
            }

            if (npc.HasBuff(ModContent.BuffType<TimeDilation>()) && !TimeDilation && (Laugicality.zaWarudo > 0 || TimeManagement.TimeAltered))
            {
                TimeDilation = true;
                Main.npc[npc.whoAmI].StrikeNPC(TIME_DILATION_DAMAGE * (npc.boss?10:1), 0, 0);
            }

            if (Laugicality.zaWarudo < 1 && !TimeManagement.TimeAltered)
                TimeDilation = false;

            if (DebuffDamageMult > 1)
                npc.lifeRegen = (int)(npc.lifeRegen * DebuffDamageMult);
            if (damage < npc.lifeRegen)
                damage = npc.lifeRegen;
        }
        public override bool PreAI(NPC npc)
        {
            if (zTimeInstanced > 0 && zImmune == false)
                return false;
            return true;
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (eFied)
            {
                if (Main.rand.Next(13) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<TrainSteam>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.8f, 0.8f);
            }
            if (spored)
            {
                if (Main.rand.Next(13) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<ShroomDust>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.8f, 0.8f);
            }
            if (DeathMarked)
            {
                if (Main.rand.Next(8) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<DeathMarkDust>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                }
                Lighting.AddLight(npc.position, 0.5f, 0.5f, 0.5f);
            }
            if (Fertile)
            {
                if (Main.rand.Next(8) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 31, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.3f, 0.3f, 0.0f);
            }
            if (Pollinated)
            {
                if (Main.rand.Next(8) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 31, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 44, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.3f, 0.3f, 0.0f);
            }
            if (slimed)
            {
                if (Main.rand.Next(13) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 116, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                //Lighting.AddLight(npc.position, 0.1f, 0.8f, 0.8f);
            }
            if (mFied)
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<Lightning>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.8f, 0.8f);
            }
            if (incineration)
            {
                if (Main.rand.Next(8) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<Magma>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.8f, 0.4f, 0f);
            }
            if (hermes || AerialWeakness)
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<HermesDust>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.8f, 0.8f);
            }
            if (lovestruck && !npc.boss)
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<HeartDust>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.8f, 0.8f);
            }
            if (frigid)
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<Frost>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.8f, 0.8f);
            }

            if (furious || npc.HasBuff(ModContent.BuffType<InfernalBuff>()))
            {
                if (Main.rand.Next(3) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<Magma>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.8f, 0.2f);
            }

            if (npc.HasBuff(ModContent.BuffType<JudgementBuff>()))
            {
                if (Main.rand.Next(2) == 0)
                {
                    int dustType = DustID.Shadowflame;
                    bool judged = false;
                    if ((npc.Center - Main.LocalPlayer.Center).Length() <= JUDGEMENT_DIST)
                    {
                        judged = true;
                        dustType = 58;
                    }
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, dustType, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= .25f;
                    if(judged)
                        Main.dust[dust].scale *= 2f;
                    if (Main.rand.Next(4) == 0)
                        Main.dust[dust].scale *= 0.5f;
                }
            }
            if (bubbly)
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<Dusts.Bubble>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 2f;
                    }
                }
            }
            if (npc.HasBuff(ModContent.BuffType<DepthBubbles>()))
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<DepthBubble>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 2f;
                    }
                }
            }
            if (Refracting)
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<Dusts.Rainbow>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 2f;
                    }
                }
            }
            if(npc.HasBuff(ModContent.BuffType<UndeathBuff>()))
            {
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Black>(), npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
            }
            if (dawn || trueDawn)
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<GoldenBubbleDust>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 2f;
                    }
                }
            }
            if (frostbite)
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<EtherialDust>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.0f, 0.4f, 0.6f);
            }
            if (steamified)
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<Steam>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.dust[dust].scale *= 0.25f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.4f, 0.4f, 0.4f);
            }
            if (npc.HasBuff(ModContent.BuffType<SpookedBuff>()))
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<SpookedDust>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.4f, 0.0f, 0.4f);
            }
            if (npc.HasBuff(ModContent.BuffType<OrbitalBuff>()))
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<GalacticLight>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.4f, 0.0f, 0.4f);
            }
            if (Sandy)
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<Sandy>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
            }
            if (Brittle)
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<Frost>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.0f, 0.4f, 0.4f);
            }
            if (Slushie)
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 37, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
            }
            if (npc.HasBuff(ModContent.BuffType<ThunderCharged>()))
            {
                int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 228, 0, 0, 0, default(Color), 1f);
                Main.dust[dust].noGravity = true;
                if (Main.rand.Next(4) == 0)
                {
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].scale *= 1.5f;
                }
            }
        }

        public override void PostAI(NPC npc)
        {
            //Za Warudo
            if ((zTimeInstanced > 0 && zImmune == false) || frigid)
            {
                npc.velocity.X *= 0;
                npc.velocity.Y *= 0;
                if (xTemp == 0 || yTemp == 0)
                {
                    xTemp = npc.position.X;
                    yTemp = npc.position.Y;
                }
                else
                {
                    npc.position.X = xTemp;
                    npc.position.Y = yTemp;
                }
            }
            else
            {
                xTemp = 0;
                yTemp = 0;
            }


            if (npc.life > npc.lifeMax)
                npc.lifeMax = npc.life;

            //Za Warudo
            if (zTimeInstanced > 0 && zImmune == false)
            {
                npc.velocity.X *= 0;
                npc.velocity.Y *= 0;
            }

        }

        public override void NPCLoot(NPC npc)
        {
            //Debuffs
            if(furious)
            {
                if(Main.netMode != 1)
                {
                    float mag = 6f;
                    float theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    int damage = 80;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, ModContent.ProjectileType<ObsidiumArrowHead>(), damage, 3f, Main.myPlayer);
                    theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, ModContent.ProjectileType<ObsidiumArrowHead>(), damage, 3f, Main.myPlayer);
                    theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, ModContent.ProjectileType<ObsidiumArrowHead>(), damage, 3f, Main.myPlayer);
                    theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, ModContent.ProjectileType<ObsidiumArrowHead>(), damage, 3f, Main.myPlayer);
                    theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, ModContent.ProjectileType<ObsidiumArrowHead>(), damage, 3f, Main.myPlayer);
                }
            }
            if(npc.HasBuff(ModContent.BuffType<UndeathBuff>()))
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, ModContent.ProjectileType<UndeathSkull>(), npc.damage + 6, 3f, Main.myPlayer);
            if (bubbly)
            {
                if (Main.netMode != 1)
                {
                    int rand = Main.rand.Next(3, 7);
                    for(int i = 0; i < rand; i++)
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (-1 + 2 * Main.rand.Next(2)) * 4, Main.rand.Next(-5, 2), ModContent.ProjectileType<Bubble>(), 20, 3f, Main.myPlayer);
                }
            }
            if (npc.HasBuff(ModContent.BuffType<DepthBubbles>()))
            {
                if (Main.netMode != 1)
                {
                    int rand = Main.rand.Next(3, 7);
                    for(int i = 0; i < rand; i++)
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (-1 + 2 * Main.rand.Next(2)) * 4, Main.rand.Next(-5, 2), ModContent.ProjectileType<PoseidonIllusion2>(), Math.Max(20, Math.Min(npc.defense, 80)), 3f, Main.myPlayer);
                }
            }
            if (dawn)
            {
                if (Main.netMode != 1)
                {
                    int rand = Main.rand.Next(3, 7);
                    for (int i = 0; i < rand; i++)
                    {
                        float mag = 8f;
                        float theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                        int damage = 32;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, ModContent.ProjectileType<DawnSpark>(), damage, 3f, Main.myPlayer);
                    }
                }
            }
            if (trueDawn)
            {
                if (Main.netMode != 1)
                {
                    int rand = Main.rand.Next(4, 9);
                    for (int i = 0; i < rand; i++)
                    {
                        float mag = 8f;
                        float theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                        int damage = 45;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, ModContent.ProjectileType<TrueDawnSpark>(), damage, 3f, Main.myPlayer);
                    }
                }
            }
            if (JunglePlague)
            {
                if (Main.netMode != 1)
                {
                    int rand = Main.rand.Next(3, 7);
                    for (int i = 0; i < rand; i++)
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (-1 + 2 * Main.rand.Next(2)) * 4, Main.rand.Next(-5, 2), ModContent.ProjectileType<JunglePlagueSporeSpread>(), 75, 3f, Main.myPlayer);
                }
            }
            if (steamified)
            {
                if (Main.netMode != 1)
                {
                    int rand = Main.rand.Next(4, 7);
                    for (int i = 0; i < rand; i++)
                    {
                        float mag = 8f;
                        float theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                        int damage = 1000;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, ModContent.ProjectileType<VulcanConjuration>(), damage, 3f, Main.myPlayer);
                    }
                }
            }
            if (DeathMarked)
            {
                Item.NewItem(npc.Center, ModContent.ItemType<Soul>());
            }
            if (attacker != -1)
            {
                if(LaugicalityPlayer.Get(Main.player[attacker]).EtherCog)
                {
                    Main.player[attacker].AddBuff(ModContent.BuffType<Annihilation>(), 10 * 60, false);
                    LaugicalityPlayer.Get(Main.player[attacker]).AnnihilationDamageBoost += .2f;
                }
            }
            if (plays == 0)
                plays = 1;
            if(lovestruck && !npc.boss)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 58); //Drop Hearts
                if(Main.rand.Next(1, 3) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 58);
                }
            }
            //Soul Drops
            if (npc.lifeMax > 5 && npc.value > 0f && Main.hardMode)
            {
                if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSkyHeight && Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SoulOfSought>());
                }
                if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneUnderworldHeight && Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SoulOfHaught>());
                }
                if (LaugicalityPlayer.Get(Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)]).zoneObsidium && Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SoulOfHaught>());
                }
            }
            //Misc Materials
            if (npc.type == 113)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<NullShard>(), Main.rand.Next(1,4));
            }
            if (npc.type == 4)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<TastyMorsel>(), 1);
            }
            if(npc.type == NPCID.IceQueen)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RoyalIce>(), 1);
            if(npc.type == NPCID.GoblinSummoner)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Shadowflame>(), Main.rand.Next(2, 5));
            GetWeaponAndAccDrops(npc);
        }
        public override Color? GetAlpha(NPC npc, Color drawColor)
        {
            if (Fertile)
            {
                drawColor.R = Math.Max((byte)drawColor.R, (byte)255);
                drawColor.G = Math.Max((byte)drawColor.G, (byte)255);
                drawColor.B = Math.Min((byte)drawColor.B, (byte)125);

                return drawColor;
            }
            return null;
        }

        public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
        {
            base.ModifyHitByItem(npc, player, item, ref damage, ref knockback, ref crit);
            if (AerialWeakness && player.Center.Y < npc.position.Y)
                damage += 6;
            if (Brittle)
                damage += (int)(player.velocity.Length() / 3);
            if (Refracting)
            {
                float theta = (float)(Math.PI * Main.rand.NextDouble() * 2);
                Vector2 newVel = new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                newVel *= 6;
                int id = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, newVel.X, newVel.Y, ModContent.ProjectileType<GemShard>(), Math.Min(Math.Max(npc.defense, 4), 80), 0, Main.myPlayer);
                Main.projectile[id].ai[1] = Main.rand.Next(6);
            }
            if (npc.HasBuff(ModContent.BuffType<JudgementBuff>()))
            {
                if (Vector2.Distance(npc.Center, player.Center) <= JUDGEMENT_DIST)
                    damage += 12;
            }
            if (npc.HasBuff(ModContent.BuffType<Furious>()))
            {
                float theta = (float)(Math.PI * Main.rand.NextDouble() * 2);
                Vector2 newVel = new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                newVel *= 8;
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, newVel.X, newVel.Y, ModContent.ProjectileType<MarsIllusion2>(), damage, 0, Main.myPlayer);
            }
            if (npc.HasBuff(ModContent.BuffType<ThunderCharged>()))
            {
                float theta = (float)(Math.PI * Main.rand.NextDouble() * 2);
                Vector2 newVel = new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                newVel *= 8;
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, newVel.X, newVel.Y, ModContent.ProjectileType<Bolt>(), damage, 0, Main.myPlayer);
            }
            if (npc.HasBuff(ModContent.BuffType<EerinessBuff>()) && HitDelay > 0)
            {
                damage += damage * (int)(HitDelay / 60f / 5f); //+20% damage per second
            }
            if (npc.HasBuff(ModContent.BuffType<OrbitalBuff>()) && player.ZoneSkyHeight)
                damage += (int)(damage * .33);
            if (npc.HasBuff(ModContent.BuffType<SpookedBuff>()))
            {
                if (!ItemTypesHitBy.Contains(item.type))
                    ItemTypesHitBy.Add(item.type);
                
                    damage += 5 * (ItemTypesHitBy.Count + ProjectileTypesHitBy.Count);
            }
            else if(ItemTypesHitBy.Count + ProjectileTypesHitBy.Count > 0)
            {
                ProjectileTypesHitBy.Clear();
                ItemTypesHitBy.Clear();
            }
            HitDelay = 0;
        }

        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            base.ModifyHitByProjectile(npc, projectile, ref damage, ref knockback, ref crit, ref hitDirection);
            if (Pollinated && LaugicalityVars.BeeProjectiles.Contains(projectile.type))
            {
                Main.projectile[projectile.whoAmI].penetrate = 1;
                damage = (int)(damage * 1.5);
            }
            if (AerialWeakness && Main.player.GetLength(0) > projectile.owner && Main.player[projectile.owner].Center.Y < npc.position.Y)
                damage += 6;
            if (Brittle)
                damage += (int)(projectile.velocity.Length() / 3);
            if (Refracting && Main.netMode != 1 && projectile.type != ModContent.ProjectileType<NPCGemShard>())
            {
                float theta = (float)(Math.PI * Main.rand.NextDouble() * 2);
                Vector2 newVel = new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                newVel *= 6;
                int id = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, newVel.X, newVel.Y, ModContent.ProjectileType<NPCGemShard>(), Math.Min(Math.Max(npc.defense, 4), 80), 0, Main.myPlayer);
                Main.projectile[id].ai[1] = Main.rand.Next(6);
            }
            if(Slushie && projectile.type != ModContent.ProjectileType<SlushballProjectile>() && LaugicalityVars.SnowballProjectiles.Contains(projectile.type))
            {
                damage += 6;
            }
            if (npc.HasBuff(ModContent.BuffType<JudgementBuff>()))
            {
                if (Vector2.Distance(npc.Center, Main.player[projectile.owner].Center) <= JUDGEMENT_DIST)
                    damage += 12;
            }
            if (npc.HasBuff(ModContent.BuffType<Furious>()) && projectile.type != ModContent.ProjectileType<MarsIllusion2>())
            {
                float theta = (float)(Math.PI * Main.rand.NextDouble() * 2);
                Vector2 newVel = new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                newVel *= 8;
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, newVel.X, newVel.Y, ModContent.ProjectileType<MarsIllusion2>(), damage, 0, Main.myPlayer);
            }
            if (npc.HasBuff(ModContent.BuffType<ThunderCharged>()) && projectile.type != ModContent.ProjectileType<Bolt>())
            {
                float theta = (float)(Math.PI * Main.rand.NextDouble() * 2);
                Vector2 newVel = new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                newVel *= 8;
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, newVel.X, newVel.Y, ModContent.ProjectileType<Bolt>(), damage, 0, Main.myPlayer);
            }
            if (npc.HasBuff(ModContent.BuffType<EerinessBuff>()) && HitDelay > 0)
            {
                damage += (int)(damage * HitDelay / 60f / 5f); //+20% damage per second
            }
            if (npc.HasBuff(ModContent.BuffType<OrbitalBuff>()) && projectile.owner > -1 && Main.player[projectile.owner].ZoneSkyHeight)
                damage += (int)(damage * .33);
            if (npc.HasBuff(ModContent.BuffType<SpookedBuff>()))
            {
                if (!ProjectileTypesHitBy.Contains(projectile.type))
                    ProjectileTypesHitBy.Add(projectile.type);
                if (ItemTypesHitBy.Count + ProjectileTypesHitBy.Count > 0)
                    damage += 5 * (ItemTypesHitBy.Count + ProjectileTypesHitBy.Count);
            }
            else if (ItemTypesHitBy.Count + ProjectileTypesHitBy.Count > 0)
            {
                ProjectileTypesHitBy.Clear();
                ItemTypesHitBy.Clear();
            }
            HitDelay = 0;
        }

        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
        {
            base.OnHitByProjectile(npc, projectile, damage, knockback, crit);
            if (Fertile && LaugicalityVars.SeedProjectiles.Contains(projectile.type))
                NumSeeds++;
            if (spored && LaugicalityVars.ShroomProjectiles.Contains(projectile.type) && Main.projectile[projectile.whoAmI].ai[0] == 0)
            {
                Main.projectile[projectile.whoAmI].scale *= 1.5f;
                Main.projectile[projectile.whoAmI].penetrate = -1;
                Main.projectile[projectile.whoAmI].damage = (int)(Main.projectile[projectile.whoAmI].damage * 1.5f);
                Main.projectile[projectile.whoAmI].ai[0] = 1;
            }
        }

        private void GetWeaponAndAccDrops(NPC npc)
        {
            if (npc.type == NPCID.Mothron && Main.rand.Next(4) == 0)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SaturnsRings>(), 1);
            if (npc.type == NPCID.DukeFishron && !Main.expertMode && Main.rand.Next(6) == 0)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<PoseidonsTide>(), 1);
            if (npc.type == NPCID.IceGolem && Main.rand.Next(6) == 0)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<CongealedFrostCore>(), 1);
            if (npc.type == NPCID.MourningWood && Main.rand.Next(10) == 0)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SpineChiller>(), 1);
        }

        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public int TIME_DILATION_DAMAGE = 400;
    }
}