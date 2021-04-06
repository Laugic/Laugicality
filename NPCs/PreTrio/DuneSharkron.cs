using System;
using Laugicality.Dusts;
using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Laugicality.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    [AutoloadBossHead]
    public class DuneSharkron : ModNPC
    {
        public bool Enraged { get; set; }
        private int AIPhase { get; set; }
        private int PrevAIPhase { get; set; }
        private int Frame { get; set; }
        private int JumpNum { get; set; }
        private Vector2 TargetPos;
        private bool Angry { get; set; }

        public override void SetStaticDefaults()
        {
            LaugicalityVars.eNPCs.Add(npc.type);
            DisplayName.SetDefault("Dune Sharkron");
        }

        public override void SetDefaults()
        {
            npc.width = 150;
            npc.height = 60;
            npc.damage = 25;
            npc.defense = 12;
            npc.aiStyle = -1;
            npc.lifeMax = 2000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/DuneSharkron");
            bossBag = ModContent.ItemType<DuneSharkronTreasureBag>();
            npc.scale = 1.25f;
            PrevAIPhase = AIPhase = 0;
            Angry = false;
            npc.ai[1] = 0;
            npc.ai[0] = -1;
            TargetPos = npc.Center;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 3500 + numPlayers * 3000;
            npc.damage = 50;
        }

        private void CheckEnrage()
        {
            Player player = Main.player[npc.target];
            if (player.active && player.statLife > 0)
                Enraged = !player.ZoneDesert;
            else
                Enraged = true;

            npc.netUpdate = true;
        }

        public override void AI()
        {
            CheckEnrage();
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
            if(npc.life < npc.lifeMax / 2 && !Angry)
            {
                Angry = true;
                SandnadoSpawn();
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
            }
        }

        private void Effects()
        {
            npc.spriteDirection = -Math.Sign(npc.velocity.X);
        }

        private void PickAI()
        {
            //Debug AI
            switch (AIPhase)
            {
                case 0:
                    InitializeAI();
                    break;
                case 1:
                    TripleJumpAI();
                    break;
                case 2:
                    JumpDashAI();
                    break;
                case 3:
                    LeapAI();
                    break;
                case 4:
                    TransitionAI();
                    break;
                default:
                    DespawnAI();
                    break;
            }
            //AIPhase = 4;
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
            if(npc.ai[0] > Math.PI * 2 || npc.ai[0] < 0)
            {
                npc.ai[0] = 0;
                TargetPos = Main.player[npc.target].Center;
            }
            npc.ai[0] += (float)Math.PI / 180;
            var newPos = TargetPos;
            newPos.X += (float)Math.Cos(npc.ai[0]) * 600;
            newPos.Y += 100;
            newPos.Y += (float)Math.Sin(npc.ai[0] * 3) * 100;
            MoveTowards(newPos);
            npc.rotation = (float)Math.Atan2((double)npc.velocity.Y * -npc.spriteDirection, (double)npc.velocity.X * -npc.spriteDirection);
            npc.ai[1]++;
            if (npc.ai[1] > 6 * 60 || (npc.ai[1] > 2 * 60 && Main.rand.Next(90) == 0))
            {
                npc.ai[1] = 0;
                npc.ai[0] = -1;
                switch (PrevAIPhase)
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
                if (Main.expertMode && Angry && Main.rand.Next(2) == 0)
                    SandnadoSpawn();
            }
        }

        private void LeapAI()
        {
            if(npc.ai[1] == 0)
            {
                TargetPos = npc.Center;
                TargetPos.Y = Main.player[npc.target].Center.Y + 60;
            }
            if (npc.ai[1] < 60)
            {
                MoveTowards(TargetPos);
                npc.rotation = 0;
            }
            if (npc.ai[1] == 60)
            {
                TargetPos = Main.player[npc.target].Center;
                TargetPos.Y -= 40;
                npc.velocity = npc.Center - TargetPos;
                npc.velocity.Normalize();
                npc.velocity *= -16;
            }
            if(npc.ai[1] > 60)
            {
                if (npc.Distance(TargetPos) > 1600)
                    Slow();
                else
                {
                    npc.velocity.Y = (float)Math.Min(8, npc.velocity.Y + .05f);
                    if(npc.position.Y < Main.player[npc.target].Center.Y)
                        npc.velocity.Y = (float)Math.Min(8, npc.velocity.Y + .15f);
                }
                npc.rotation = (float)Math.Atan2((double)npc.velocity.Y * -npc.spriteDirection, (double)npc.velocity.X * -npc.spriteDirection);
            }
            npc.ai[1]++;
            if (npc.ai[1] > 3 * 60)
                Transition();
        }

        private void JumpDashAI()
        {
            if(npc.ai[1] == 0)
            {
                TargetPos = npc.Center;
                TargetPos.Y = Main.player[npc.target].Center.Y;
            }
            if(npc.ai[1] < 60)
            {
                var dirToPlayer = npc.Center - Main.player[npc.target].Center;
                dirToPlayer.Normalize();
                npc.rotation = -(float)Math.PI / 2;
                MoveTowardsSharp(TargetPos);
            }
            if (npc.ai[1] == 60)
            {
                TargetPos = Main.player[npc.target].Center;
                npc.velocity = npc.Center - TargetPos;
                npc.velocity.Normalize();
                npc.velocity *= -16;
                CrystalBurst((Angry ? 30 : 20), false, (Angry ? 6 : 3));
                if (Angry)
                    SandnadoSpawn();
            }
            if (npc.ai[1] > 60)
            {
                if (npc.Distance(TargetPos) > 1800)
                    Slow();
                npc.rotation = (float)Math.Atan2((double)npc.velocity.Y * -npc.spriteDirection, (double)npc.velocity.X * -npc.spriteDirection);
            }
            npc.ai[1]++;
            if (npc.ai[1] > 2 * 60 + 30)
                Transition();
        }

        private void TripleJumpAI()
        {
            npc.rotation = (float)Math.Atan2((double)npc.velocity.Y * -npc.spriteDirection, (double)npc.velocity.X * -npc.spriteDirection);
            if (npc.ai[1] % 2 == 0)
            {
                TargetPos = Main.player[npc.target].Center;
                TargetPos.Y += 240;
                MoveTowardsSharp(TargetPos);
                if (npc.Distance(TargetPos) < 12 || Main.rand.Next(60) == 0)
                {
                    npc.velocity.Y = -16;
                    npc.velocity.X *= .9f;
                    if (npc.ai[1] == 4)
                        SandnadoSpawn();
                    npc.ai[1]++;
                }
            }
            else
            {
                npc.velocity.Y = Math.Min(npc.velocity.Y + .2f, 16);
                if(npc.velocity.Y > 0 && npc.ai[0] != npc.ai[1])
                {
                    npc.ai[0] = npc.ai[1];
                    CrystalBurst((Angry ? 30 : 20), false, (Angry ? 6 : 3));
                }
                if(npc.position.Y > Main.player[npc.target].Center.Y && npc.velocity.Y > 0)
                {
                    npc.ai[1]++;
                    if (npc.ai[1] > 5)
                        Transition();
                }
            }
        }

        private void SandnadoSpawn()
        {
            if(Main.netMode != 1)
                Projectile.NewProjectile(npc.Center, new Vector2(0, -4), ModContent.ProjectileType<Sandnado>(), npc.damage / 4, 3f, npc.target, 0, 1);
        }

        private void CrystalBurst(int amount, bool above, float speed)
        {
            if (amount < 1)
                amount = 1;
            for (int i = 0; i < amount; i++)
            {
                float theta = Main.rand.NextFloat() * (float)Math.PI * (above?-1:2);
                float mag = speed + Main.rand.NextFloat() * (Angry ? 6 : 3);
                if(Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag), ModContent.ProjectileType<SharkronCrystalShard>(), npc.damage / 4, 3f);
            }
        }

        private void InitializeAI()
        {
            npc.TargetClosest(false);
            TargetPos = Main.player[npc.target].Center;
            AIPhase = 4;
            npc.ai[1] = 0;
            npc.ai[0] = -1;
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
            newVel *= Math.Min(Vector2.Distance(npc.Center, targetPos) / 4, Math.Min(npc.velocity.Length() + .6f, 8));
            npc.velocity = npc.velocity * .8f + newVel * .2f;
        }

        private void MoveTowardsSharp(Vector2 targetPos)
        {
            Vector2 newVel = Vector2.Normalize(targetPos - npc.Center);
            newVel *= Math.Min(Vector2.Distance(npc.Center, targetPos) / 4, Math.Min(npc.velocity.Length() + .6f, 8));
            npc.velocity = newVel;
        }

        private void MoveTowardsAtSpeed(Vector2 targetPos, float mag)
        {
            Vector2 newVel = Vector2.Normalize(targetPos - npc.Center);
            newVel *= Math.Min(mag, npc.velocity.Length() + .6f);
            npc.velocity = newVel;
        }

        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            base.ModifyHitByProjectile(projectile, ref damage, ref knockback, ref crit, ref hitDirection);
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frame.Y = 0;// frameHeight * Frame;
        }

        private void Transition()
        {
            PrevAIPhase = AIPhase;
            AIPhase = 4;
            npc.ai[1] = 0;
            npc.ai[0] = -1;
            Frame = 0;
        }
        public override void NPCLoot()
        {
            if (LaugicalityWorld.downedEtheria)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Etheramind>(), 1);

            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AncientShard>(), Main.rand.Next(1, 3));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Crystilla>(), Main.rand.Next(4, 11));

                int ran = Main.rand.Next(1, 8);
                if (ran == 1) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SandstorminaBottle, 1);
                if (ran == 2) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FlyingCarpet, 1);
                if (ran == 3) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BandofRegeneration, 1);
                if (ran == 4) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagicMirror, 1);
                if (ran == 5) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CloudinaBottle, 1);
                if (ran == 6) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HermesBoots, 1);
                if (ran == 7) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EnchantedBoomerang, 1);
            }

            if (Main.expertMode)
                npc.DropBossBags();
            if(Main.rand.Next(10) == 0)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DuneSharkronTrophy>(), 1);

            LaugicalityWorld.downedDuneSharkron = true;
        }


        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 188;
        }
    }
}
