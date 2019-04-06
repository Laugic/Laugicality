using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.RockTwins
{
    [AutoloadBossHead]
    public class Dioritus : ModNPC
    {

        public static Random rnd = new Random();
        public int spawn = 0;
        public bool stage2 = false;
        public int phase = 0;
        public int dir = 0;
        public int vdir = 0;
        public float accel = 0f;
        public float maxAccel = 20f;
        public float vaccel = 0f;
        public float maxVaccel = 20f;
        public bool boosted = false;
        public int delay = 0;
        public int maxDelay = 60;
        public int range = 2000;
        public int damage = 0;
        public int shoot = 0;
        public int reload = 160;
        public int moveType = 1;
        public int hovDir = 1;
        public int moveDelay = 600;
        public int vDir = 2;
        public int attacks = 0;
        public bool attacking = false;
        public bool bitherial = true;
        public int plays = 0;
        public int attackDuration = 0;
        public static bool andio = false;
        public static float theta = 0f;
        public float tVel = 0f;
        public float vel = 0f;
        public float distance = 0;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.enpCs.Add(npc.type);
            DisplayName.SetDefault("Dioritus");
            //Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            distance = 0;
            tVel = 0f;
            vel = 0f;
            theta = 0;
            andio = false;
            attackDuration = 0;
            plays = 1;
            bitherial = true;
            attacks = 0;
            attacking = false;
            moveDelay = 600;
            hovDir = 1;
            vDir = 1;
            moveType = 1;
            shoot = 0;
            reload = 240;
            phase = 1;
            damage = 0;
            maxDelay = 60;
            range = 200;
            maxAccel = 14f;
            maxVaccel = 20f;
            accel = 0f;
            vaccel = 0f;
            spawn = 0;
            dir = 0;
            vdir = 0;
            delay = reload;
            npc.width = 64;
            npc.height = 64;
            npc.damage = 56;
            npc.defense = 14;
            npc.aiStyle = 0;
            npc.lifeMax = 4000;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 99f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/RockPhase3");
            damage = 32;
            //bossBag = mod.ItemType("RagnarTreasureBag");
            //npc.scale = 2f;
            if (NPC.CountNPCS(mod.NPCType("AnDio3")) > 1)
            {
                npc.active = false;
                npc.life = 0;
            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            plays = numPlayers;
            npc.lifeMax = 5000 + numPlayers * 1000;
            npc.damage = 99;
            reload = 220;
            damage = 40;
            if (NPC.CountNPCS(mod.NPCType("AnDio3")) > 1)
            {
                npc.active = false;
                npc.life = 0;
            }
        }


        public override void AI()
        {
            bitherial = true;
            Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 127, 0f, 0f);

            //DESPAWN
            int despawn = 0;
            if (!Main.player[npc.target].active || Main.player[npc.target].dead || Main.player[npc.target].ZoneRockLayerHeight == false)
            {
                npc.TargetClosest(true);
                if (!Main.player[npc.target].active || Main.player[npc.target].dead || Main.dayTime)
                {
                    if (despawn == 0)
                        despawn++;
                }
            }
            if (despawn >= 1 || andio)
            {
                despawn++;
                //ResetValues();
                npc.noTileCollide = true;
                npc.velocity.Y = 8f;
                if (despawn >= 300)
                    npc.active = false;
            }

            Vector2 delta = Main.player[npc.target].Center - npc.Center;
            float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);

            npc.netUpdate = true;

            npc.ai[0] -= 3.14f / 120;
            
            //Disabling if AnDio is on
            if (NPC.CountNPCS(mod.NPCType("AnDio3")) > 0 || NPC.CountNPCS(mod.NPCType("AnDio2")) > 0 || NPC.CountNPCS(mod.NPCType("AnDio1")) > 0)
                npc.active = false;

            //Movement if only Dioritus
            if (NPC.CountNPCS(mod.NPCType("Andesia")) == 0)
            {
                //Checking if it should initiate phase 3 already
                if (LaugicalityWorld.downedAndesia && LaugicalityWorld.downedDioritus && NPC.CountNPCS(mod.NPCType("Andesia")) == 0 && Main.netMode != 1)
                {
                    int and = NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y + npc.height, mod.NPCType("Andesia"));
                    Main.npc[and].ai[3] = npc.whoAmI;
                }
                    //Checking which direction to move when spawned
                    if (dir == 0)
                {
                    if (delta.X < 0) dir = 1;
                    else dir = -1;
                }

                //Moving across top of screen
                if (moveType == 1)
                {
                    attacking = false;
                    //Horizontal Movement
                    npc.velocity.X = accel;
                    if (npc.position.X < Main.player[npc.target].position.X - 400 && hovDir == -1)
                    {
                        hovDir = 1;
                    }
                    if (npc.position.X > Main.player[npc.target].position.X + 400 && hovDir == 1)
                    {
                        hovDir = -1;
                    }
                    if (Math.Abs(accel) < maxAccel) { accel += (float)hovDir / 4f; }
                    else { accel *= .9f; }

                    //Vertical Movement
                    npc.velocity.Y = vaccel;
                    if (npc.position.Y - Main.player[npc.target].position.Y + 280 > 0) { vDir = -1; }
                    if (npc.position.Y - Main.player[npc.target].position.Y + 280 < 0) { vDir = 1; }
                    if (Math.Abs(vaccel) < maxVaccel / 4) { vaccel += (float)vDir / 3f; }
                    else { vaccel *= .2f; }
                    npc.velocity.Y = vaccel;
                    if (boosted == false)
                    {
                        if (Math.Abs(npc.position.Y - Main.player[npc.target].position.Y + 280) > 20)
                        {
                            if (npc.position.Y - Main.player[npc.target].position.Y + 280 < 0)
                            {
                                if (vaccel < maxVaccel) vaccel += .4f;
                            }
                            if (npc.position.Y - Main.player[npc.target].position.Y + 280 > 0)
                            {
                                if (vaccel < maxVaccel) vaccel -= .4f;
                            }
                        }
                        else
                        {
                            if (Math.Abs(vaccel) > .01f) vaccel *= .5f;
                            else vaccel = 0f;
                        }
                    }
                    else vaccel = 0;

                    //Smash Attack
                    if (Math.Abs(delta.X) < 10 && attacks >= 8 && moveType == 1)
                    {
                        attacks = 0;
                        moveType = 2;
                        npc.velocity.X = 0;
                        npc.velocity.Y = 0;
                    }

                }

                if (moveType == 2)
                {
                    attacking = true;
                    npc.velocity.Y = 14;
                    npc.velocity.X = 0;
                    vaccel = 0;
                    accel = 0;
                    if (npc.position.Y - Main.player[npc.target].position.Y > 280)
                    {
                        moveType = 1;
                    }
                }
            }
            else if(Main.player[npc.target].statLife > 0)
            {
                reload = 320;
                int mag = 320;
                double targetX = Main.player[npc.target].position.X + mag * Math.Cos(npc.ai[0] + 3.14) - npc.width / 2;
                double targetY = Main.player[npc.target].position.Y + mag * Math.Sin(npc.ai[0] + 3.14);
                //npc.position.X = (float)targetX;
                //npc.position.Y = (float)targetY;
                distance = (float)Math.Sqrt((targetX - npc.position.X) * (targetX - npc.position.X) + (targetY - npc.position.Y) * (targetY - npc.position.Y));
                tVel = distance / 10;

                if (vel < tVel)
                {
                    vel += .1f;
                    vel *= 1.05f;
                }
                if (vel > tVel)
                {
                    vel = tVel;
                }
                npc.velocity.X = (float)Math.Abs((npc.position.X - targetX) / distance * vel);
                if (targetX < npc.position.X)
                    npc.velocity.X *= -1;
                npc.velocity.Y = (float)Math.Abs((npc.position.Y - targetY) / distance * vel);
                if (targetY < npc.position.Y)
                    npc.velocity.Y *= -1;
            }


            //Attacks
            delay--;
            if(delay <= 0)
            {
                delay = reload;
                shoot = Main.rand.Next(1, 5);
            }
            if(shoot == 1 && Main.netMode != 1)//Homing Ball
            {
                shoot = 0;
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("DioEnergyHoming"), damage / 2, 3, Main.myPlayer);
            }
            if (shoot == 2 && Main.netMode != 1)//Split Ball
            {
                shoot = 0;
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("DioEnergy"), damage / 2, 3, Main.myPlayer);
            }
            if (shoot == 3 && Main.netMode != 1)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("DioBallShot"), damage / 2, 3f, Main.myPlayer);
                shoot = 0;
                attackDuration = 1;
            }

            if (attackDuration == 30 && Main.netMode != 1)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("DioBallShot"), damage / 2, 3f, Main.myPlayer);
            }
            if (attackDuration == 60 && Main.netMode != 1)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("DioBallShot"), damage / 2, 3f, Main.myPlayer);
            }
            if (attackDuration == 90 && Main.netMode != 1)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("DioBallShot"), damage / 2, 3f, Main.myPlayer);
            }
            if (attackDuration > 0)
                attackDuration++;
            if (attackDuration > 90)
            {
                attackDuration = 0;
            }
            if (shoot == 4 && Main.netMode != 1)//Split Ball
            {
                int rng = 480;
                int yHeight = 480;
                shoot = 0;
                Projectile.NewProjectile(Main.player[npc.target].position.X, Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("DioShard"), damage / 2, 3, Main.myPlayer);
            }
            npc.netUpdate = true;
        }

        public override bool CheckDead()
        {
            LaugicalityWorld.downedDioritus = true;
            if (NPC.CountNPCS(mod.NPCType("Andesia")) == 0 && NPC.CountNPCS(mod.NPCType("AnDio2")) == 0 && Main.netMode != 1)
                NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y + npc.height, mod.NPCType("Andesia"));
            else
            {
                Main.npc[(int)npc.ai[3]].position.X -= 10000;
                if (Main.netMode != 1)
                    NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y + npc.height, mod.NPCType("AnDio2"));
            }
            Main.PlaySound(15, -1, -1 - 50, 0);
            return false;
        }

        public override void NPCLoot()
        {
        }

        public override void BossLoot(ref string name, ref int potionType)
        {

        }

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
        }


    }
}
