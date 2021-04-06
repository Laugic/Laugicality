using System;
using Laugicality.Buffs;
using Laugicality.Dusts;
using Laugicality.Items.Loot;
using Laugicality.Items.Placeable;
using Laugicality.NPCs.Slybertron;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Bosses
{
    [AutoloadBossHead]
    public class TheAnnihilator : ModNPC
    {
        int Phase { get; set; }
        int FrameDelay { get; set; } = 0;
        int Delay { get; set; } = 0;
        bool Attacking { get; set; } = false;
        public static bool on = false;
        public override void SetStaticDefaults()
        {
            LaugicalityVars.eNPCs.Add(npc.type);
            DisplayName.SetDefault("The Annihilator");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults()
        {
            npc.width = 200;
            npc.height = 240;
            npc.damage = 80;
            npc.defense = 32;
            npc.lifeMax = 30000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Annihilator");
            bossBag = ModContent.ItemType<AnnihilatorTreasureBag>();
            npc.buffImmune[ModContent.BuffType<Steamy>()] = true;
            Phase = 0;
            FrameDelay = 0;
            Delay = 0;
            Attacking = false;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 60000 + numPlayers * 30000;
            npc.damage = 120;
        }

        public override void AI()
        {
            Calculations();
            PhaseChecks();
            if(Attacking)
                Attacks();
            Movement();
            Visuals();
        }

        private void Visuals()
        {
            Lighting.AddLight(npc.position, .5f, .6f, .8f);
        }

        private void Movement()
        {
            if (Main.player[(int)npc.target].statLife <= 0 || !Main.player[(int)npc.target].active)
            {
                DespawnAI();
                return;
            }
            if ((!Attacking || npc.life < npc.lifeMax * .33 || (npc.life < npc.lifeMax * .5 && Main.expertMode)) && (npc.ai[2] >= 0 && npc.ai[2] < (15 - Phase) * 60 - 30))
                FollowAI();
            else
                Slow();
            if (npc.life < npc.lifeMax * .75)
                Teleportation();
        }

        private void Teleportation()
        {
            npc.ai[2]++;
            if (npc.ai[2] == (15 - Phase) * 60 - 30)
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 28);
            if (npc.ai[2] > (15 - Phase) * 60)
            {
                npc.ai[2] = -30;
                npc.velocity *= 0;
                Vector2 warp = (Main.player[npc.target].Center - npc.Center).RotatedByRandom(MathHelper.ToRadians(90));
                float mag = warp.Length();
                warp.Normalize();
                warp *= Math.Max(mag, 600);
                npc.Teleport(Main.player[npc.target].Center + warp, 1);
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
            }
        }

        private void Slow()
        {
            npc.velocity *= .95f;
        }

        private void FollowAI()
        {
            Vector2 TargetPos = Main.player[npc.target].Center;
            MoveTowardsAtSpeed(TargetPos, 3 + Phase + (Main.expertMode ? 2 : 0));
        }

        private void MoveTowardsAtSpeed(Vector2 targetPos, float mag)
        {
            Vector2 newVel = Vector2.Normalize(targetPos - npc.Center);
            newVel *= Math.Min(mag, npc.velocity.Length() + .3f);
            npc.velocity = newVel;
        }

        private void Attacks()
        {
            Delay++;
            float numBalls = 0;
            double thetaInit = 0;
            if(Delay == 1 * 60)
            {
                var attack = Main.rand.Next(4);
                switch (attack)
                {
                    case 1:
                        Main.PlaySound(SoundID.Item33, (int)npc.position.X, (int)npc.position.Y);
                        numBalls = 2 + ((npc.life < npc.lifeMax / 2)?2:0);
                        thetaInit = 0;
                        for (int i = 0; i < numBalls; i++)
                        {
                            float mag = 5;
                            if (Main.netMode != 1)
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 80, mag * (float)Math.Cos(thetaInit + (Math.PI * 2) * (i / numBalls)), mag * (float)Math.Sin(thetaInit + (Math.PI * 2) * (i / numBalls)),
                                    ModContent.ProjectileType<XOut>(), (int)(npc.damage / 4), 3);
                        }
                        break;
                    case 2:
                        Main.PlaySound(SoundID.Item33, (int)npc.position.X, (int)npc.position.Y);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 60, 0, 8, ModContent.ProjectileType<SteamyShadow>(), npc.damage / 3, 3f, npc.target);
                        /*numBalls = 10 + Main.rand.Next(6);
                        thetaInit = Math.PI;
                        for (int i = 0; i < numBalls; i++)
                        {
                            float mag = 12 + Main.rand.NextFloat() * 8;
                            if (Main.netMode != 1)
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, mag * (float)Math.Cos(thetaInit + (Math.PI) * (i / numBalls)), mag * (float)Math.Sin(thetaInit + (Math.PI) * (i / numBalls)),
                                    ModContent.ProjectileType<Electroshock>(), (int)(npc.damage / 4), 3, npc.target, .3f);
                        }*/
                        break;
                    default:
                        Main.PlaySound(SoundID.Item33, (int)npc.position.X, (int)npc.position.Y);
                        numBalls = 12 + ((npc.life < npc.lifeMax / 2)?8:0) +  Main.rand.Next(8);
                        thetaInit = Math.PI * 2 * Main.rand.NextDouble();
                        for (int i = 0; i < numBalls; i++)
                        {
                            float mag = 6 + Main.rand.NextFloat() * 4;
                            if (Main.netMode != 1)
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, mag * (float)Math.Cos(thetaInit + (Math.PI * 2) * (i / numBalls)), mag * (float)Math.Sin(thetaInit + (Math.PI * 2) * (i / numBalls)),
                                    ModContent.ProjectileType<Electroshock>(), (int)(npc.damage / 4), 3);
                        }
                        break;
                }
            }
            if (Delay > 2 * 60)
                Attacking = false;
        }

        private void PhaseChecks()
        {
            if(Phase == 0)
            {
                Phase = 1;
                PhaseChanges(Phase);
            }
            if (Phase == 1 && npc.life < npc.lifeMax * .75)
            {
                Phase = 2;
                PhaseChanges(Phase);
            }
            if (Phase == 2 && npc.life < npc.lifeMax * .5)
            {
                Phase = 3;
                PhaseChanges(Phase);
            }
            if (Phase == 3 && npc.life < npc.lifeMax * .25)
            {
                Phase = 4;
                PhaseChanges(Phase);
            }
            if (Phase == 4 && npc.life < npc.lifeMax * .1 && Main.expertMode)
            {
                Phase = 5;
                PhaseChanges(Phase);
            }
        }

        private void DespawnAI()
        {
            npc.TargetClosest();
            if (Main.player[(int)npc.target].statLife <= 0 || !Main.player[(int)npc.target].active)
                npc.position.Y += 8;
            else
                FollowAI();
        }
        private void PhaseChanges(int phase)
        {
            Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
            switch (phase)
            {
                case 1:
                    for (int i = 0; i < 4; i++)
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<SteampunkDefender>(), 0, npc.whoAmI, NPC.CountNPCS(ModContent.NPCType<SteampunkDefender>()));
                    for (int i = 0; i < 8; i++)
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<SteampunkZapper>(), 0, npc.whoAmI, NPC.CountNPCS(ModContent.NPCType<SteampunkZapper>()));
                    break;
                case 2:
                    for (int i = 0; i < 4; i++)
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<SteampunkDefender>(), 0, npc.whoAmI, NPC.CountNPCS(ModContent.NPCType<SteampunkDefender>()));
                    for (int i = 0; i < 8; i++)
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<SteampunkZapper>(), 0, npc.whoAmI, NPC.CountNPCS(ModContent.NPCType<SteampunkZapper>()));
                    break;
                case 3:
                    for (int i = 0; i < 4; i++)
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<SteampunkDefender>(), 0, npc.whoAmI, NPC.CountNPCS(ModContent.NPCType<SteampunkDefender>()));
                    for (int i = 0; i < 8; i++)
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<SteampunkZapper>(), 0, npc.whoAmI, NPC.CountNPCS(ModContent.NPCType<SteampunkZapper>()));
                    break;
                case 4:
                    for (int i = 0; i < 4; i++)
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<SteampunkDefender>(), 0, npc.whoAmI, NPC.CountNPCS(ModContent.NPCType<SteampunkDefender>()));
                    for (int i = 0; i < 8; i++)
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<SteampunkZapper>(), 0, npc.whoAmI, NPC.CountNPCS(ModContent.NPCType<SteampunkZapper>()));
                    break;
                case 5:
                    for (int i = 0; i < 4; i++)
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<SteampunkDefender>(), 0, npc.whoAmI, NPC.CountNPCS(ModContent.NPCType<SteampunkDefender>()));
                    for (int i = 0; i < 8; i++)
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<SteampunkZapper>(), 0, npc.whoAmI, NPC.CountNPCS(ModContent.NPCType<SteampunkZapper>()));
                    break;
                default:

                    break;
            }
        }

        private void Calculations()
        {
            npc.ai[0] += (float)(Math.PI / 60);
            npc.ai[1] += (float)(Math.PI / 80);
            if(!Attacking)
                Delay++;
            if (Delay > 4 * 60)
            {
                Attacking = true;
                Delay = 0;
            }
        }

        /*
        public override void AI()
        {
            npc.rotation = 0;

            if (npc.active)
                on = true;
            else
                on = false;
            if (npc.velocity.X > 12) npc.velocity.X = 12;
            if (npc.velocity.Y > 12) npc.velocity.Y = 12;
            if (npc.life < npc.lifeMax && spawn < 1 && Main.netMode != 1)
            {
                poof = true;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 1;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>(), 0, npc.whoAmI, NPC.CountNPCS(ModContent.NPCType<MechanicalCreeper>()));
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>(), 0, npc.whoAmI, NPC.CountNPCS(ModContent.NPCType<MechanicalCreeper>()));
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (npc.life < npc.lifeMax * .9 && spawn < 2 && Main.netMode != 1)
            {
                poof = true;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 2;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (npc.life < npc.lifeMax * .8 && spawn < 3 && Main.netMode != 1)
            {
                poof = true;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 3;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (npc.life < npc.lifeMax * .7 && spawn < 4 && Main.netMode != 1)
            {
                poof = true;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 4;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (npc.life < npc.lifeMax * .6 && spawn < 5 && Main.netMode != 1)
            {
                poof = true;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 5;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (npc.life < npc.lifeMax * .5 && spawn < 6 && Main.netMode != 1)
            {
                poof = true;
                if (Main.expertMode)
                {
                    npc.velocity *= 3;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalShelly>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalShelly>());
                }

                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 6;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (npc.life < npc.lifeMax * .4 && spawn < 7 && Main.netMode != 1)
            {
                poof = true;
                if (Main.expertMode)
                {
                    npc.velocity *= 3;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalShelly>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalShelly>());
                }
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 7;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (npc.life < npc.lifeMax * .3 && spawn < 8 && Main.netMode != 1)
            {
                poof = true;
                if (Main.expertMode)
                {
                    npc.velocity *= 3;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalShelly>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalShelly>());
                }
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 8;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (npc.life < npc.lifeMax * .2 && spawn < 9 && Main.netMode != 1)
            {
                poof = true;
                if (Main.expertMode)
                {
                    npc.velocity *= 2;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalShelly>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalShelly>());
                }
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 9;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (npc.life < npc.lifeMax * .12 && spawn < 10 && Main.netMode != 1)
            {
                poof = true;
                if (Main.expertMode)
                {
                    spawn = 10;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalShelly>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalShelly>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalShelly>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalShelly>());
                }
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                spawn = 10;
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (npc.life < npc.lifeMax * .02 && spawn < 11 && Main.expertMode && Main.netMode != 1)
            {
                if (Main.expertMode)
                {
                    poof = true;
                    spawn = 11;
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalSlimer>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCreeper>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalCrawler>());
                    NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<MechanicalMimic>());
                }
            }

            if (poof)
            {
                poof = false;

                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, ModContent.DustType<Steam>(), 0f, 0f);
            }

            delay++;
            int phase = 0;
            if (npc.life < npc.lifeMax * .5)
                phase = 1;
            if (delay >= 4)
            {
                delay = 0;
                frame++;
                if (frame > phase * 4 + 3)
                    frame = phase * 4;
            }
            npc.frame.Y = fHeight * frame;
        }
        */

        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            if (Main.expertMode)
                player.AddBuff(ModContent.BuffType<Steamy>(), 2 * 60 + Main.rand.Next(60), true);
        }

        public override void NPCLoot()
        {

            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get();
            if (LaugicalityWorld.downedEtheria)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<CogOfEtheria>(), 1);
            }
            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SteamBar>(), Main.rand.Next(15, 30));
               
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SoulOfThought>(), Main.rand.Next(20, 40));
            }

            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            if (Main.rand.Next(10) == 0)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AnnihilatorTrophy>(), 1);
            LaugicalityWorld.downedAnnihilator = true;

        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 499;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = 0;
            FrameDelay++;
            if (FrameDelay >= 16)
                FrameDelay = 0;
            npc.frame.Y = frameHeight * (((npc.life < npc.lifeMax * .5)?4:0) + FrameDelay / 4);
        }


        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Microsoft.Xna.Framework.Color color9 = Lighting.GetColor((int)((double)npc.position.X + (double)npc.width * 0.5) / 16, (int)(((double)npc.position.Y + (double)npc.height * 0.5) / 16.0));
            float num66 = 0f;
            Vector2 vector11 = new Vector2((float)(Main.npcTexture[npc.type].Width / 2), (float)(Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2));
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (npc.spriteDirection == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            Microsoft.Xna.Framework.Rectangle frame6 = npc.frame;
            Microsoft.Xna.Framework.Color alpha15 = npc.GetAlpha(color9);
            float alpha = 1.25f * (1f - (float)npc.life / (float)npc.lifeMax);
            alpha *= alpha;
            alpha = Math.Min(alpha, 1);
            alpha15.R = (byte)((float)alpha15.R * alpha);
            alpha15.G = (byte)((float)alpha15.G * alpha);
            alpha15.B = (byte)((float)alpha15.B * alpha);
            alpha15.A = (byte)((float)alpha15.A * alpha);
            for (int num213 = 0; num213 < 4; num213++)
            {
                Vector2 position9 = npc.position;
                float num214 = Math.Abs(npc.Center.X - Main.player[Main.myPlayer].Center.X);
                float num215 = Math.Abs(npc.Center.Y - Main.player[Main.myPlayer].Center.Y);
                if (num213 == 0 || num213 == 2)
                {
                    position9.X = Main.player[Main.myPlayer].Center.X + num214;
                }
                else
                {
                    position9.X = Main.player[Main.myPlayer].Center.X - num214;
                }
                position9.X -= (float)(npc.width / 2);
                if (num213 == 0 || num213 == 1)
                {
                    position9.Y = Main.player[Main.myPlayer].Center.Y + num215;
                }
                else
                {
                    position9.Y = Main.player[Main.myPlayer].Center.Y - num215;
                }
                position9.Y -= (float)(npc.height / 2);
                Main.spriteBatch.Draw(Main.npcTexture[npc.type], new Vector2(position9.X - Main.screenPosition.X + (float)(npc.width / 2) - (float)Main.npcTexture[npc.type].Width * npc.scale / 2f + vector11.X * npc.scale, position9.Y - Main.screenPosition.Y + (float)npc.height - (float)Main.npcTexture[npc.type].Height * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + vector11.Y * npc.scale + num66 + npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(frame6), alpha15, npc.rotation, vector11, npc.scale, spriteEffects, 0f);
            }
            Main.spriteBatch.Draw(Main.npcTexture[npc.type], new Vector2(npc.position.X - Main.screenPosition.X + (float)(npc.width / 2) - (float)Main.npcTexture[npc.type].Width * npc.scale / 2f + vector11.X * npc.scale, npc.position.Y - Main.screenPosition.Y + (float)npc.height - (float)Main.npcTexture[npc.type].Height * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + vector11.Y * npc.scale + num66 + npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(frame6), npc.GetAlpha(color9), npc.rotation, vector11, npc.scale, spriteEffects, 0f);
            return false;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 0f;
            return null;
        }
        /*
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = Main.rand.Next(139, 143);
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}*/
    }
}
