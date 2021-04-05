using System;
using Laugicality.Items.Equipables;
using Laugicality.Items.Loot;
using Laugicality.Items.Placeable;
using Laugicality.Items.Weapons.Range;
using Laugicality.NPCs.Obsidium;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    [AutoloadBossHead]
    public class Ragnar : ModNPC
    {
        private int AIPhase { get; set; }
        private int PrevAIPhase { get; set; }
        private int Counter { get; set; }
        private int Frame { get; set; }
        private Vector2 TargetPos;
        private bool Angry { get; set; }

        public override void SetStaticDefaults()
        {
            LaugicalityVars.eNPCs.Add(npc.type);
            DisplayName.SetDefault("Ragnar");
            Main.npcFrameCount[npc.type] = 2;
        }
        public override void SetDefaults()
        {
            npc.width = 88;
            npc.height = 96;
            npc.damage = 35;
            npc.defense = 16;
            npc.aiStyle = 0;
            npc.lifeMax = 4200;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.buffImmune[24] = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Ragnar2");
            bossBag = ModContent.ItemType<RagnarTreasureBag>();
            PrevAIPhase = AIPhase = 0;
            Counter = 0;
            TargetPos = npc.Center;
            Angry = false;
            npc.ai[0] = -1;
            Frame = 0;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 8400 + numPlayers * 2000;
            npc.damage = 70;
        }

        public override void AI()
        {
            HealthCheck();
            PickAI();
            Effects();
        }

        private void HealthCheck()
        {
            if (Main.player[(int)npc.target].statLife <= 0 || !Main.player[(int)npc.target].active)
            {
                AIPhase = 6;
                return;
            }
            if (npc.life < (npc.lifeMax * 2) / 3 && !Angry && Counter >= 0)
            {
                Counter = -1;
                AIPhase = 5;
            }
        }

        private void Effects()
        {
            npc.spriteDirection = (int)(npc.velocity.X / Math.Abs(npc.velocity.X));
            npc.netUpdate = true;
        }

        private void PickAI()
        {
            switch(AIPhase)
            {
                case 0:
                    InitializeAI();
                    break;
                case 1:
                    RuneAI();
                    break;
                case 2:
                    FireballAI();
                    break;
                case 3:
                    SmashAI();
                    break;
                case 4:
                    TransitionAI();
                    break;
                case 5:
                    SummonHandAI();
                    break;
                default:
                    DespawnAI();
                    break;
            }
        }

        private void DespawnAI()
        {
            npc.TargetClosest();
            if (Main.player[(int)npc.target].statLife <= 0 || !Main.player[(int)npc.target].active)
                npc.position.Y += 8;
            else
                Transition();
        }

        private void TransitionAI()
        {
            TargetPos = Main.player[npc.target].Center;
            MoveTowardsAtSpeed(TargetPos, Angry?5:4 + (Main.expertMode?2:0));
            Counter++;
            if ((Counter > 2 * 60 && Main.rand.Next(60) == 0) || Counter > 4 * 60)
            {
                Counter = 0;
                switch(PrevAIPhase)
                {
                    case 1:
                        AIPhase = Main.rand.Next(2, 4);
                        break;
                    case 2:
                        AIPhase = 1 + 2 * Main.rand.Next(2);
                        break;
                    case 3:
                        AIPhase = Main.rand.Next(1, 3);
                        break;
                    default:
                        AIPhase = 1;
                        break;
                }
            }
        }

        private void SmashAI()
        {
            Counter++;
            if(Counter < 2 * 60)
            {
                TargetPos = Main.player[npc.target].position;
                TargetPos.Y -= 250;
                MoveTowards(TargetPos);
            }
            if(Counter >= 2 * 60 && Counter < 2 * 60 + 30)
            {
                Frame = 1;
                QuickSlow();
            }
            if(Counter > 2 * 60 + 30 && Counter < 3 * 60)
            {
                npc.velocity.Y = 14;
                npc.velocity.X = 0;
                Frame = 0;
            }
            if(Counter == 3 * 60 + 30)
            {
                npc.velocity.Y = 0;
                if(Main.netMode != 1)
                {
                    for(int i = 0; i < 8; i++)
                    {
                        Projectile.NewProjectile(Main.player[npc.target].position.X - 400 + Main.rand.Next(800), Main.player[npc.target].position.Y - 420 - Main.rand.Next(50), Angry?(-1 + 2 * Main.rand.NextFloat()):0, 8 + 4 * Main.rand.NextFloat(), ModContent.ProjectileType<Ragnarock>(), npc.damage / 4, 3, Main.myPlayer);
                    }
                }
            }
            if(Counter > 3 * 60 + 30)
                Transition();
        }

        private void SummonHandAI()
        {
            if(!Main.expertMode)
            {
                Angry = true;
                Transition();
                return;
            }
            Slow();
            Frame = 1;
            if(Counter == -1)
            {
                if (Main.netMode != 1)
                {
                    int n = NPC.NewNPC((int)npc.Center.X + 1200, (int)npc.Center.Y, ModContent.NPCType<RagnarHand>());
                    Main.npc[n].ai[0] = 0;
                    Main.npc[n].ai[1] = npc.whoAmI;
                    n = NPC.NewNPC((int)npc.Center.X - 1200, (int)npc.Center.Y, ModContent.NPCType<RagnarHand>());
                    Main.npc[n].ai[0] = 1;
                    Main.npc[n].ai[1] = npc.whoAmI;
                }
            }
            Counter--;
            if(Counter < -3 * 60)
            {
                Angry = true;
                Transition();
            }
        }

        private void FireballAI()
        {
            Slow();
            Frame = 1;
            Counter++;
            if(Counter > 60 && Counter < 4 * 60)
            {
                double theta = Math.PI + Main.rand.NextDouble() * Math.PI;
                float mag = 4 + Main.rand.NextFloat() * 2;
                if(Counter % 6 == 0 && Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center.X - 10 + Main.rand.Next(20), npc.Center.Y - 20 - Main.rand.Next(10), (float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag, ModContent.ProjectileType<GravityFireball>(), (int)(npc.damage / 4), 3, Main.myPlayer);

            }
            if (Counter > 4 * 60)
                Frame = 0;
            if (Counter > 5 * 60)
                Transition();
        }

        private void RuneAI()
        {
            if(npc.ai[0] != -1 && Main.npc[(int)npc.ai[0]].active)
            {
                ExplodeRune();
                return;
            }
            if (Counter == 0)
            {
                TargetPos = Main.player[npc.target].Center;
                Counter++;
            }
            MoveTowards(TargetPos);
            if (Vector2.Distance(npc.Center, TargetPos) < 40)
                SummonRune();
        }

        private void SummonRune()
        {
            Slow();
            Counter++;
            Frame = 1;

            if (Counter >= 60)
            {
                if (Main.netMode != 1)
                    npc.ai[0] = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Ragnarune>());
                Main.npc[(int)npc.ai[0]].ai[0] = npc.whoAmI;
                Transition();
            }
        }

        private void ExplodeRune()
        {
            QuickSlow();
            Counter++;
            Frame = 1;
            if (npc.ai[0] == -1)
            {
                npc.ai[0] = -1;
                Counter = 0;
                Frame = 0;
            }
            NPC rune = Main.npc[(int)npc.ai[0]];
            rune.ai[2] = 1;
            if (Counter >= 90 && rune.active)
            {
                float numBalls = 8 + Main.rand.Next(4) + (Main.expertMode ? 2 : 0) + (Angry ? 4 : 0);
                double thetaInit = Math.PI * 2 * Main.rand.NextDouble();
                for(int i = 0; i < numBalls; i++)
                {
                    float mag = 5 + Main.rand.NextFloat() * 2 + (Angry ? 2 : 0);
                    if (Main.netMode != 1)
                        Projectile.NewProjectile(rune.Center.X + 40, rune.Center.Y + 40, mag * (float)Math.Cos(thetaInit + (Math.PI * 2) * (i / numBalls)), mag * (float)Math.Sin(thetaInit + (Math.PI * 2) * (i / numBalls)),
                            ModContent.ProjectileType<GravityFireball>(), (int)(npc.damage / 4), 3, Main.myPlayer);
                }
                rune.active = false;
                npc.ai[0] = -1;
                Counter = 0;
                Frame = 0;
            }
            if (!rune.active)
            {
                npc.ai[0] = -1;
                Counter = 0;
                Frame = 0;
            }
        }

        private void InitializeAI()
        {
            npc.TargetClosest(false);
            TargetPos = Main.player[npc.target].Center;
            AIPhase = 1;
            Counter = 0;
        }

        private void Slow()
        {
            npc.velocity *= .95f;
        }

        private void QuickSlow()
        {
            npc.velocity *= .9f;
        }

        private void MoveTowards(Vector2 targetPos)
        {
            Vector2 newVel = Vector2.Normalize(targetPos - npc.Center);
            newVel *= Math.Min(Vector2.Distance(npc.Center, targetPos) / 4, npc.velocity.Length() + .6f);
            npc.velocity = newVel;
        }

        private void MoveTowardsAtSpeed(Vector2 targetPos, float mag)
        {
            Vector2 newVel = Vector2.Normalize(targetPos - npc.Center);
            newVel *= Math.Min(mag, npc.velocity.Length() + .6f);
            npc.velocity = newVel;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frame.Y = frameHeight * Frame;
        }

        private void Transition()
        {
            PrevAIPhase = AIPhase;
            AIPhase = 4;
            Counter = 0;
            Frame = 0;
        }
        public override void NPCLoot()
        {
            if (LaugicalityWorld.downedEtheria)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<MoltenEtheria>(), 1);
            }

            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DarkShard>(), Main.rand.Next(1, 3));
                int obsidiumItem = 0;
                int rand = Main.rand.Next(7);
                switch (rand)
                {
                    case 0:
                        obsidiumItem = ItemID.LavaCharm;
                        break;
                    case 1:
                        obsidiumItem = ModContent.ItemType<ObsidiumLily>();
                        break;
                    case 2:
                        obsidiumItem = ModContent.ItemType<FireDust>();
                        break;
                    case 3:
                        obsidiumItem = ModContent.ItemType<Eruption>();
                        break;
                    case 4:
                        obsidiumItem = ModContent.ItemType<CrystalizedMagma>();
                        break;
                    case 5:
                        obsidiumItem = ModContent.ItemType<Ragnashia>();
                        break;
                    default:
                        obsidiumItem = ModContent.ItemType<MagmaHeart>();
                        break;
                }
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, obsidiumItem, 1);
                if(Main.rand.Next(4) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BlackIce>(), 1);
                if (Main.rand.Next(10) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RagnarTrophy>(), 1);
            }
            if (!LaugicalityWorld.downedRagnar)
                Main.NewText("Fury runs through the Obsidium Caverns.", 250, 150, 50);
            LaugicalityWorld.downedRagnar = true;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 188;
        }

    }
}