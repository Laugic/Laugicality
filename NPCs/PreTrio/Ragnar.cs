using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    [AutoloadBossHead]
    public class Ragnar : ModNPC
    {

        public static Random rnd = new Random();
        public int phase = 0;
        public int delay = 0;
        public int maxDelay = 60;
        public int damage = 0;
        public int shoot = 0;
        public int moveType = 1;
        public bool attacking = false;
        public bool bitherial = true;
        public float vel = 0f;
        public float tVel = 0f;
        public float vMax = 14f;
        public float vAccel = .2f;
        public float vMag = 0f;
        public double theta = 0;
        public double theta2 = 0;
        public int cycle = 0;
        public int cycle2 = 0;
        public int rotRate = 60;
        public int reload = 0;
        public int reloadMax = 120;
        public static float sizeMult = Main.maxTilesX / 2600f;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.eNPCs.Add(npc.type);
            DisplayName.SetDefault("Ragnar");
            //Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            reload = 0;
            rotRate = 60;
            cycle2 = 0;
            cycle = 0;
            moveType = 1;
            theta = 0;
            theta2 = 0;
            shoot = 0;
            vMag = 0f;
            vMax = 14f;
            tVel = 0f;
            phase = 0;
            bitherial = true;
            npc.width = 88;
            npc.height = 96;
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
            bossBag = ModContent.ItemType("RagnarTreasureBag");
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
            Player player = Main.player[npc.target];
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (Main.player[npc.target].statLife <= 0) npc.position.Y += 60;
            if (modPlayer.zoneObsidium == false)
                npc.dontTakeDamage = true;
            else
                npc.dontTakeDamage = false;


            Vector2 delta = Main.player[npc.target].Center - npc.Center;
            float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);

            float mag = 360;
            theta -= Math.PI / rotRate;
            if (theta < -Math.PI * 2)
            {
                cycle++;
                theta += Math.PI * 2;
            }


            Vector2 rot;
            rot.X = (float)Math.Cos(theta) * mag;
            rot.Y = (float)Math.Sin(theta) * mag;
            Vector2 targetPos = player.Center;
            reload++;
            if (moveType == 1)
            {
                vMax = 10f;
                rotRate = 120;
                theta2 -= Math.PI / 140;

                if (theta2 < -Math.PI * 2)
                {
                    theta2 += Math.PI * 2;
                    cycle2++;
                }
                reloadMax = 120;
                if (reload > reloadMax)
                {
                    reload = 0;
                    shoot = 1;
                }
                Vector2 rot1;
                rot1.X = (float)Math.Cos(theta2) * 320;
                rot1.Y = (float)Math.Sin(theta) * 120;
                targetPos = player.Center + rot1;
                targetPos.Y -= 180;
                if (cycle2 >= 2)
                {
                    if (Math.Abs(npc.position.X - player.position.X) < 4 && npc.Center.Y < player.Center.Y)
                    {
                        cycle2 = 0;
                        cycle = 0;
                        moveType = 2;
                    }
                }
            }
            if (moveType == 3)
            {
                moveType = 4;
                vMax = 8f;
                rotRate = 90;
                Vector2 rot3;
                rot3.X = 0;
                rot3.Y = (float)Math.Sin(theta) * mag;
                targetPos = player.Center + rot3;
                if (cycle >= 8)
                {
                    moveType++;
                    cycle = 0;
                }
                reloadMax = 90;
                if (reload > reloadMax)
                {
                    reload = 0;
                    shoot = 1;
                }
            }
            if (moveType == 4)
            {
                vMax = 12f;
                rotRate = 120;
                targetPos = player.Center + rot;
                if (npc.life > npc.lifeMax / 2)
                {
                    reloadMax = 90;
                    if (reload > reloadMax)
                    {
                        reload = 0;
                        shoot = 1;
                    }
                }
                else
                {
                    reloadMax = 120;
                    if (reload > reloadMax)
                    {
                        reload = 0;
                        shoot = 2;
                    }
                }
                if (cycle >= 4)
                {
                    if (Math.Abs(npc.position.X - player.position.X) < 4 && npc.Center.Y < player.Center.Y)
                    {
                        cycle = 0;
                        moveType++;
                    }
                }
            }
            if (moveType == 2 || moveType == 5)
            {
                vMax = 14f;
                attacking = true;
                npc.velocity.Y = 14;
                npc.velocity.X = 0;
                if (npc.position.Y - Main.player[npc.target].position.Y > 280)
                {
                    cycle = 0;
                    shoot = 2;
                    moveType += 1;
                    if (moveType == 6)
                        moveType = 1;
                }
            }
            else
            {
                float dist = Vector2.Distance(targetPos, npc.Center);
                tVel = dist / 15;
                if (vMag < vMax && vMag < tVel)
                {
                    vMag += vAccel;
                    vMag = tVel;
                }

                if (vMag > tVel)
                {
                    vMag = tVel;
                }

                if (vMag > vMax)
                {
                    vMag = vMax;
                }

                if (dist != 0)
                {
                    npc.velocity = npc.DirectionTo(targetPos) * vMag;
                }
            }

            //Attacks
            //Normal Shot
            if (shoot == 1 && Main.netMode != 1)
            {
                shoot = 0;
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, ModContent.ProjectileType("RockFalling"), (int)(damage * .7), 3, Main.myPlayer);
                if (Main.expertMode)
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, ModContent.ProjectileType("RockLooseMini"), damage / 2, 3, Main.myPlayer);
            }
            //Big Boom
            if (shoot == 2 && Main.netMode != 1)
            {
                shoot = 0;
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 5, ModContent.ProjectileType("RockFalling"), (int)(damage * .7), 3, Main.myPlayer);

                if (Main.expertMode && npc.life < npc.lifeMax * 2 / 3)
                {
                    if (attacking)
                    {
                        if (Main.rand.Next(3) == 0)
                            NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), mod.NPCType("MagmaCaster"));
                        else if (Main.rand.Next(2) == 0)
                            NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), mod.NPCType("MagmatipedeHead"));
                        else
                            NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), mod.NPCType("ObsidiumElemental"));
                    }
                    else if (Main.rand.Next(5) == 0)
                    {
                        if (Main.rand.Next(3) == 0)
                            NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), mod.NPCType("MagmaCaster"));
                        else if (Main.rand.Next(2) == 0)
                            NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), mod.NPCType("MagmatipedeHead"));
                        else
                            NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), mod.NPCType("ObsidiumElemental"));
                    }
                }
                attacking = false;
            }
        }



        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            if (Main.expertMode)
            {
                target.AddBuff(BuffID.OnFire, 90, true);
            }
        }

        public override void NPCLoot()
        {
            if (LaugicalityWorld.downedEtheria)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType("MoltenEtheria"), 1);
            }

            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType("DarkShard"), Main.rand.Next(1, 3));
                int ran = Main.rand.Next(1, 7);
                if (ran == 1) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 49, 1);
                if (ran == 2) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagicMirror, 1);
                if (ran == 3) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 53, 1);
                if (ran == 4) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HermesBoots, 1);
                if (ran == 5) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EnchantedBoomerang, 1);
                if (ran == 6) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LavaCharm, 1);

            }
            if(!LaugicalityWorld.downedRagnar)
                Main.NewText("Fury runs through the Obsidium Caverns.", 250, 150, 50);
            LaugicalityWorld.downedRagnar = true;
        }

        /*
        public override void FindFrame(int frameHeight)
        {
            frameHeight = 96;
            if (attacking)
            {
                npc.frame.Y = frameHeight;
            }
            else
            {
                npc.frame.Y = 0;
            }
        }*/


        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 188;
        }

    }
}