using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.RockTwins
{
    [AutoloadBossHead]
    public class Andesia : ModNPC
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
        public bool bitherial = true;
        public int plays = 0;
        public static int laser = 0;
        public int laserCharge = 0;
        public static Vector2 center;
        public static Vector2 position;
        public static Player target;
        public static bool andio = false;
        public static float theta = 0f;
        public float rotSpeed = 1f;
        public static double posX = 0;
        public static double posY = 0;
        public static int dist = 0;
        public static int laserBallNum;
        public int spiralDur = 0;
        public int spiralDelay = 0;
        public float tVel = 0f;
        public float vel = 0f;
        public float distance = 0;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.eNPCs.Add(npc.type);
            DisplayName.SetDefault("Andesia");
        }

        public override void SetDefaults()
        {
            npc.ai[1] = 0;
            distance = 0;
            tVel = 0f;
            vel = 0f;
            spiralDur = 0;
            spiralDelay = 0;
            laserBallNum = 1;
            rotSpeed = 1f;
            theta = 0f;
            laserCharge = 0;
            andio = false;
            laser = 0;
            plays = 1;
            bitherial = true;
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
            npc.width = 60;
            npc.height = 42;
            npc.damage = 56;
            npc.defense = 16;
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
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            plays = numPlayers;
            npc.lifeMax = 5000 + numPlayers * 1000;
            npc.damage = 88;
            reload = 220;
            delay = reload;
            damage = 40;
        }

        public override void AI()
        {
            center = npc.Center;
            position = npc.position;
            bitherial = true;

            //DESPAWN
            int despawn = 0;
            if (!Main.player[npc.target].active || Main.player[npc.target].dead || Main.player[npc.target].statLife < 1 || Main.player[npc.target].ZoneRockLayerHeight == false)
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
            npc.spriteDirection = 0;
            target = Main.player[npc.target];
            npc.netUpdate = true;

            posX = npc.Center.X;
            posY = npc.Center.Y;
            
            //Disabling if AnDio is on
            if (NPC.CountNPCS(mod.NPCType<AnDio3>()) > 0 || NPC.CountNPCS(mod.NPCType("AnDio2")) > 0 || NPC.CountNPCS(mod.NPCType("AnDio1")) > 0)
                npc.active = false;

            //Movement if only Andesia
            //if (NPC.CountNPCS(mod.NPCType<Dioritus>()) == 0)
            {
                //Checking which direction to move when spawned
                if (dir == 0)
                {
                    if (delta.X < 0) dir = 1;
                    else dir = -1;
                }

                //Hovering
                if (moveType == 1)
                {
                    moveDelay -= 1;
                    if (moveDelay <= 0)
                    {
                        moveDelay = 900;
                        moveType = 2;
                    }
                    //Horizontal Movement
                    npc.velocity.X = accel;
                    if (delta.X > 0) { hovDir = 1; }
                    if (delta.X < 0) { hovDir = -1; }
                    if (Math.Abs(accel) < maxAccel / 3) { accel += (float)hovDir / 5f; }
                    else { accel *= .98f; }

                    //Vertical Movement
                    npc.velocity.Y = vaccel;
                    if (npc.position.Y - Main.player[npc.target].position.Y + 70 > 0) { vDir = -1; }
                    if (npc.position.Y - Main.player[npc.target].position.Y + 70 < 0) { vDir = 1; }
                    if (Math.Abs(vaccel) < maxVaccel / 4) { vaccel += (float)vDir / 3f; }
                    else { vaccel *= .98f; }
                }

                //Floating
                if (moveType == 2)
                {
                    moveDelay -= 1;
                    if (moveDelay <= 0)
                    {
                        moveDelay = 4;
                        moveType = 3;
                    }
                    //Horizontal Movement
                    npc.velocity.X = accel;
                    if (npc.position.X < Main.player[npc.target].position.X - 200 && hovDir == -1) { hovDir = 1;  }
                    if (npc.position.X > Main.player[npc.target].position.X + 200 && hovDir == 1) { hovDir = -1; }
                    if (Math.Abs(accel) < maxAccel) { accel += (float)hovDir / 3f; }
                    else { accel *= .98f; }

                    //Vertical Movement
                    npc.velocity.Y = vaccel;
                    if (npc.position.Y - Main.player[npc.target].position.Y + 70 > 0) { vDir = -1; }
                    if (npc.position.Y - Main.player[npc.target].position.Y + 70 < 0) { vDir = 1; }
                    if (Math.Abs(vaccel) < maxVaccel / 6) { vaccel += (float)vDir / 6f; }
                    else { vaccel *= .98f; }
                }

                //Dashing
                if (moveType == 3)
                {

                    //Horizontal Movement
                    npc.velocity.X = accel;
                    if (dir == 1)
                    {
                        if (accel < maxAccel / 2)
                        {
                            accel += .2f;
                        }
                        else
                        {
                            if (boosted == false) //Play boosted sound effect
                            {
                                moveDelay -= 1;
                                boosted = true;
                            }
                            accel = maxAccel;
                        }
                        if (delta.X < -range)
                        {
                            boosted = false;
                            dir = -1;
                        }
                    }
                    if (dir == -1)
                    {
                        if (accel > maxAccel / -2)
                        {
                            accel -= .2f;
                        }
                        else
                        {
                            if (boosted == false) //Play boosted sound effect
                            {
                                moveDelay -= 1;
                                boosted = true;
                            }
                            accel = -maxAccel;
                        }
                        if (delta.X > range)
                        {
                            boosted = false;
                            dir = 1;
                        }
                    }

                    //Vertical Movement
                    npc.velocity.Y = vaccel;
                    if (boosted == false)
                    {
                        if (Math.Abs(delta.Y) > 40)
                        {
                            if (delta.Y > 40)
                            {
                                if (vaccel < maxVaccel) vaccel += .4f;
                            }
                            if (delta.Y < -40)
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

                    if (moveDelay <= 0)
                    {
                        moveDelay = 600;
                        moveType = 1;
                    }
                }
            }
            /*else if (Main.player[npc.target].statLife > 0)
            {
                int dio = (int)npc.ai[3];
                Main.npc[dio].ai[3] = npc.whoAmI;
                int mag = 320;
                reload = 320;
                double targetX = Main.player[npc.target].position.X + mag * Math.Cos(Main.npc[(int)npc.ai[3]].ai[0]) - npc.width / 2;
                double targetY = Main.player[npc.target].position.Y + mag * Math.Sin(Main.npc[(int)npc.ai[3]].ai[0]);
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
            }*/
            
            //Attacks
            delay--;
            if (delay <= 0)
            {
                delay = reload;
                shoot = Main.rand.Next(1, 5);
            }
            if (shoot == 1 && Main.netMode != 1)//Lazer
            {
                shoot = 0;
                laserCharge = 1;
                rotSpeed = .25f;
                dist = 0;
            }
            if(laserCharge > 0)
            {
                laserCharge++;
                delay = reload;
                if (NPC.CountNPCS(mod.NPCType("LaserBall")) < 1)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        int laser = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("LaserBall"));
                        Main.npc[laser].ai[3] = npc.whoAmI;
                    }
                }
                if (laserCharge < 60)
                {
                    dist += 2;
                    rotSpeed += .02f;
                }
                else if(laserCharge > 80)
                {
                    dist -= 3;
                    rotSpeed += .02f;
                }
                if (laserCharge > 120)
                {
                    LaserBall.life = 0;
                    laser = 120;
                    laserCharge = 0;
                }
                //npc.ai[0] Rotation & Position Setting
                npc.ai[0] += 3.14f / 60 * rotSpeed;

            }
            if (laser > 0)
            {
                delay = reload;
                laser--;
                if(Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("AndeLaser3"), damage / 2, 3, Main.myPlayer);
            }
            if (shoot == 2)//Spiral Orbs
            {
                shoot = 0;
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("AndeEnergy"), damage / 2, 3, Main.myPlayer);
                spiralDur++;
            }
            if (spiralDur > 0)
            {
                spiralDur++;
                if (spiralDur > 100)
                    spiralDur = 0;
                spiralDelay++;
                if (spiralDelay >= 20)
                {
                    if (Main.netMode != 1)
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("AndeEnergy"), damage / 2, 3f, Main.myPlayer);
                    spiralDelay = 0;
                }
            }
            if (shoot == 3 && Main.netMode != 1)//8 way
            {
                int dist = 3;
                Projectile.NewProjectile(Main.player[npc.target].position.X + 140 * dist, Main.player[npc.target].position.Y, -.7f, 0, mod.ProjectileType("AndeBall"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X + 100 * dist, Main.player[npc.target].position.Y + 100 * dist, -.5f, -.5f, mod.ProjectileType("AndeBall"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X, Main.player[npc.target].position.Y + 140 * dist, 0, -.7f, mod.ProjectileType("AndeBall"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - 100 * dist, Main.player[npc.target].position.Y + 100 * dist, .5f, -.5f, mod.ProjectileType("AndeBall"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - 140 * dist, Main.player[npc.target].position.Y, .7f, 0, mod.ProjectileType("AndeBall"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - 100 * dist, Main.player[npc.target].position.Y - 100 * dist, .5f, .5f, mod.ProjectileType("AndeBall"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X, Main.player[npc.target].position.Y - 140 * dist, 0, .7f, mod.ProjectileType("AndeBall"), damage / 2, 3f, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X + 100 * dist, Main.player[npc.target].position.Y - 100 * dist, -.5f, .5f, mod.ProjectileType("AndeBall"), damage / 2, 3f, Main.myPlayer);
                shoot = 0;
            }

            if (shoot == 4 && Main.netMode != 1)//Split Ball
            {
                int rng = 480;
                int yHeight = -480;
                shoot = 0;
                Projectile.NewProjectile(Main.player[npc.target].position.X, Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
                Projectile.NewProjectile(Main.player[npc.target].position.X - rng + Main.rand.Next(rng * 2), Main.player[npc.target].position.Y - yHeight, 0, 0, mod.ProjectileType("AndeShard"), damage / 2, 3, Main.myPlayer);
            }
            npc.netUpdate = true;
        }


        public override bool CheckDead()
        {
            LaugicalityWorld.downedAndesia = true;
            if (NPC.CountNPCS(mod.NPCType<Dioritus>()) == 0 && NPC.CountNPCS(mod.NPCType("AnDio2")) == 0 && Main.netMode != 1)
            {
                NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y + npc.height, mod.NPCType<Dioritus>());
            }
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

    }
}
