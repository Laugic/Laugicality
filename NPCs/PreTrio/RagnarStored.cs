/*using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace Laugicality.NPCs.PreTrio
{
    [AutoloadBossHead]
    public class Ragnar : ModNPC
    {
        
        int phase = 0;
        int damage = 30;
        int despawn = 0;
        int moveType = 0;
        int movementCounter = 0;
        int moveDelay = 0;
        int attackCounter = 0;
        bool attacking = false;
        bool bitherial = true;
        int rand = 0;
        float vel = 0f;
        float tVel = 0f;
        float vMax = 14f;
        float vAccel = .2f;
        float vMag = 0f;
        double theta = 0;
        Vector2 targetPos;
        Vector2 rot;
        Player player;

        public static float sizeMult = Main.maxTilesX / 2600f;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.ENPCs.Add(npc.type);
            DisplayName.SetDefault("Ragnar");
        }

        public override void SetDefaults()
        {
            attackCounter = 0;
            moveDelay = 0;
            movementCounter = 0;
            despawn = 0;
            moveType = 0;
            theta = 0;
            vMag = 0f;
            vMax = 8f;
            tVel = 0f;
            phase = 0;
            bitherial = true;
            npc.width = 80;
            npc.height = 120;
            npc.damage = 28;
            npc.defense = 16;
            npc.aiStyle = 0;
            npc.lifeMax = 3200;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 99f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.buffImmune[24] = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Ragnar");
            damage = 32;
            bossBag = ModContent.ItemType<RagnarTreasureBag>();
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 4400 + numPlayers * 800;
            npc.damage = 36;
            damage = 34;
        }

        public override bool PreAI()
        {
            npc.TargetClosest(true);
            return true;
        }

        public override void AI()
        {
            bitherial = true;
            Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 127, 0f, 0f);
            player = Main.player[npc.target];
            var modPlayer = LaugicalityPlayer.Get(player);

            Retarget();
            DespawnCheck();
            GetMovement(player);
            SpriteEffects();
            GetAttacks();
        }

        private void Retarget()
        {
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            npc.netUpdate = true;
        }

        private void DespawnCheck()
        {
            if (!Main.player[npc.target].active || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
                if (!Main.player[npc.target].active || Main.player[npc.target].dead)
                {
                    if (despawn == 0)
                        despawn++;
                }
            }
            else
                despawn = 0;
            if (despawn >= 1)
            {
                despawn++;
                npc.noTileCollide = true;
                if (despawn >= 300)
                    npc.active = false;
            }
            npc.dontTakeDamage = !Main.player[npc.target].GetModPlayer<LaugicalityPlayer>(mod).ZoneObsidium;
        }

        private void GetMovement(Player player)
        {
            if (moveType == 0)
                EncircleMovement(player);
            if (moveType == 1)
                SmashMovement(player);
            if (moveType == 2)
                FollowMovement(player);
            if (moveType == 3)
                HoverMovement(player);
            MoveToTargetPos();
            npc.ai[1] = moveType;
        }

        private void EncircleMovement(Player player)
        {
            theta -= Math.PI / 120;
            if (theta < -2 * Math.PI)
            {
                theta += Math.PI * 2;
                movementCounter++;
            }
            float distance = 440f;
            targetPos = player.Center;
            targetPos.X += (float)Math.Cos(theta) * distance;
            targetPos.Y += (float)Math.Sin(theta) * distance;

            if (movementCounter > 4)
            {
                movementCounter = 0;
                moveType++;
            }
        }

        private void SmashMovement(Player player)
        {
            if(movementCounter % 2 == 0)
            {
                targetPos = player.Center;
                targetPos.Y -= 320;
                moveDelay++;
                if(moveDelay > 2 * 60)
                {
                    targetPos.Y += 640;
                    moveDelay = 0;
                    movementCounter++;
                }
            }
            else
            {
                float dist = Vector2.Distance(targetPos, npc.Center);
                if(dist < 48)
                {
                    movementCounter++;
                    SmashAttack();
                }
            }
            if(movementCounter >= 6)
            {
                movementCounter = 0;
                moveType++;
            }
        }

        private void FollowMovement(Player player)
        {
            targetPos = player.Center;
            movementCounter++;
            if (movementCounter >= 5 * 60)
            {
                movementCounter = 0;
                moveType++;
            }
        }

        private void HoverMovement(Player player)
        {
            theta -= Math.PI / 40;
            if (theta < -4 * Math.PI)
            {
                theta += Math.PI * 4;
                movementCounter++;
            }
            float distance = 360f;
            targetPos = player.Center;
            targetPos.X += (float)Math.Cos(theta / 2) * distance;
            targetPos.Y -= 320;
            targetPos.Y += (float)Math.Sin(theta) * distance;
            movementCounter++;
            if (movementCounter >= 8 * 60)
            {
                movementCounter = 0;
                moveType = 0;
            }
        }

        private void MoveToTargetPos()
        {
            float dist = Vector2.Distance(targetPos, npc.Center);
            tVel = dist / 16;
            if (vMag < vMax && vMag < tVel)
            {
                vMag += vAccel;
                vMag = tVel;
            }
            if (vMag > tVel)
                vMag = tVel;
            if (vMag > vMax)
                vMag = vMax;
            if (dist != 0)
                npc.velocity = npc.DirectionTo(targetPos) * vMag;
        }


        private void GetAttacks()
        {
            if (moveType == 0)
                EncircleAttack();
            if (moveType == 2)
                FollowAttack();
            if (moveType == 3)
                HoverAttack();
            MoveToTargetPos();
            npc.ai[1] = moveType;
        }

        private void EncircleAttack()
        {
            attackCounter++;
            if (rand == 0)
                rand = Main.rand.Next(1, 60);
            if(attackCounter > 60 + rand)
            {
                rand = Main.rand.Next(1, 60);
                attackCounter = 0;
                Vector2 velocity;
                velocity.X = 0;
                velocity.Y = 0;
                if (Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<RockLooseMini>(), damage, 5f);
            }
        }

        private void SmashAttack()
        {
            Vector2 velocity;
            velocity.X = 0;
            velocity.Y = 0;
            if (Main.netMode != 1)
                Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<LavaGeyeser>(), damage, 5f);
        }

        private void FollowAttack()
        {
            attackCounter++;
            if (rand == 0)
                rand = Main.rand.Next(1, 60);
            if (attackCounter > 60 + rand)
            {
                rand = Main.rand.Next(1, 60);
                attackCounter = 0;
                Vector2 velocity;
                velocity.X = 0;
                velocity.Y = 0;
                if (Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Fireball>(), damage, 5f);
            }
        }

        private void HoverAttack()
        {
            attackCounter++;
            if (rand == 0)
                rand = Main.rand.Next(1, 60);
            if (attackCounter > 45 + rand)
            {
                rand = Main.rand.Next(1, 60);
                attackCounter = 0;
                Vector2 velocity;
                velocity.X = 0;
                velocity.Y = 10;
                if (Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<RockFalling>(), damage, 5f);
            }
        }

        private void SpriteEffects()
        {
            if (npc.velocity.X < 0)
                npc.direction = 0;
            else
                npc.direction = 1;
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            if (Main.expertMode)
                target.AddBuff(BuffID.OnFire, 5 * 60, true);
        }

        public override void NPCLoot()
        {
            if (LaugicalityWorld.downedEtheria)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<MoltenEtheria>(), 1);
            if (Main.expertMode)
                npc.DropBossBags();
            else
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DarkShard>(), Main.rand.Next(1, 3));
                int ran = Main.rand.Next(1, 7);
                if (ran == 1) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 49, 1);
                if (ran == 2) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagicMirror, 1);
                if (ran == 3) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 53, 1);
                if (ran == 4) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HermesBoots, 1);
                if (ran == 5) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EnchantedBoomerang, 1);
                if (ran == 6) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LavaCharm, 1);
            }
            LaugicalityWorld.downedRagnar = true;
        }
        
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 188;
        }
        
    }
}
*/



/*Ragnar New
 * 
 * 
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
        }*/