using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using System;

namespace Laugicality.Projectiles
{

    public class AndesiaProbe : HoverShooter
    {
        public int vMax = 0;
        public float vAccel = 0;
        public float tVel = 0; //Target Velocity
        public float vMag = 0;
        public int index = 0;
        public float theta = 0f;
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            theta = 0f;
            index = 0;
            vMax = 14;
            vAccel = .1f;
            projectile.netImportant = true;
            projectile.width = 24;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = .5f;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            inertia = 12f;
            shoot = mod.ProjectileType("AndeshiardOrb");
            shootCool = 60f;
            shootSpeed = 18f;
        }

        public override void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (player.dead)
            {
                modPlayer.rTwins = false;
            }
            if (modPlayer.rTwins)
            {
                projectile.timeLeft = 2;
            }
        }

        public override void CreateDust()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
            if (projectile.ai[0] == 0f)
            {
                if (Main.rand.Next(5) == 0)
                {
                    int dust = Dust.NewDust(projectile.position, projectile.width / 2, projectile.height / 2, mod.DustType("Blue"));
                    Main.dust[dust].velocity.Y -= 1.2f;
                }
            }
            else
            {
                if (Main.rand.Next(3) == 0)
                {
                    Vector2 dustVel = projectile.velocity;
                    if (dustVel != Vector2.Zero)
                    {
                        dustVel.Normalize();
                    }
                    int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("Blue"));
                    Main.dust[dust].velocity -= 1.2f * dustVel;
                }
            }
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
        }

        public override void Behavior()
        {
            Player player = Main.player[projectile.owner];
            if (index == 0)
                index = player.ownedProjectileCounts[mod.ProjectileType("AndesiaProbe")];
            float spacing = (float)projectile.width * spacingMult;
            projectile.tileCollide = false;
            theta += (float)(Math.PI / 40);
            float mag = 48 + index * 16;
            Vector2 rot = projectile.position;
            rot.X = (float)Math.Cos(theta) * mag;
            rot.Y = (float)Math.Sin(theta) * mag;
            Vector2 targetPos = player.Center + rot;
            Vector2 direction = targetPos - projectile.Center;
            float dist = Vector2.Distance(targetPos, projectile.Center);
            tVel = dist / 15;
            if (vMag < vMax && vMag < tVel)
            {
                vMag += vAccel;
            }

            if (vMag > tVel)
            {
                vMag = tVel;
            }

            if (dist != 0)
            {
                projectile.velocity = projectile.DirectionTo(targetPos) * vMag;
            }
                
            
            targetPos = projectile.position;
            float targetDist = viewDist;
            bool target = false;
            projectile.tileCollide = false;
            if (player.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                if (Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height))
                {
                    targetDist = Vector2.Distance(projectile.Center, targetPos);
                    targetPos = npc.Center;
                    target = true;
                }
            }
            else for (int k = 0; k < 200; k++)
                {
                    NPC npc = Main.npc[k];
                    if (npc.CanBeChasedBy(this, false))
                    {
                        float distance = Vector2.Distance(npc.Center, projectile.Center);
                        if ((distance < targetDist || !target) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height))
                        {
                            targetDist = distance;
                            targetPos = npc.Center;
                            target = true;
                        }
                    }
                }

            if (Vector2.Distance(player.Center, projectile.Center) > (target ? 1000f : 500f))
            {
                projectile.ai[0] = 1f;
                projectile.netUpdate = true;
            }
            if (projectile.ai[0] == 1f)
            {
                projectile.tileCollide = false;
            }
            if (target && projectile.ai[0] == 0f)
            {
                Vector2 tPos = targetPos + rot;
                direction = tPos - projectile.Center;
                dist = Vector2.Distance(tPos, projectile.Center);
                tVel = dist / 15;
                if (vMag < vMax && vMag < tVel)
                {
                    vMag += vAccel;
                }
                
                if (vMag > tVel)
                {
                    vMag = tVel;
                }

                if (dist != 0)
                {
                    projectile.velocity = projectile.DirectionTo(tPos) * vMag;
                }
            }
            else
            {
                if (!Collision.CanHitLine(projectile.Center, 1, 1, player.Center, 1, 1))
                {
                    projectile.ai[0] = 1f;
                }
                float speed = 6f;
                if (projectile.ai[0] == 1f)
                {
                    speed = 15f;
                }
                Vector2 center = projectile.Center;
                direction = player.Center - center;
                projectile.ai[1] = 3600f;
                projectile.netUpdate = true;
                int num = 1;
                for (int k = 0; k < projectile.whoAmI; k++)
                {
                    if (Main.projectile[k].active && Main.projectile[k].owner == projectile.owner && Main.projectile[k].type == projectile.type)
                    {
                        num++;
                    }
                }
                direction.X -= (float)((10 + num * 40) * player.direction);
                direction.Y -= 70f;
                float distanceTo = direction.Length();
                if (distanceTo > 200f && speed < 9f)
                {
                    speed = 9f;
                }
                if (distanceTo < 100f && projectile.ai[0] == 1f && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
                {
                    projectile.ai[0] = 0f;
                    projectile.netUpdate = true;
                }
                if (distanceTo > 2000f)
                {
                    projectile.Center = player.Center;
                }
                if (distanceTo > 48f)
                {
                    direction.Normalize();
                    direction *= speed;
                    float temp = inertia / 2f;
                    //projectile.velocity = (projectile.velocity * temp + direction) / (temp + 1);
                }
                else
                {
                    //projectile.direction = Main.player[projectile.owner].direction;
                    //projectile.velocity *= (float)Math.Pow(0.9, 40.0 / inertia);
                }
            }
            //projectile.rotation = projectile.velocity.X * 0.05f;
            SelectFrame();
            CreateDust();
            /*if (projectile.velocity.X > 0f)
            {
                projectile.spriteDirection = (projectile.direction = -1);
            }
            else if (projectile.velocity.X < 0f)
            {
                projectile.spriteDirection = (projectile.direction = 1);
            }*/
            if (projectile.ai[1] > 0f)
            {
                projectile.ai[1] += 1f;
                if (Main.rand.Next(3) == 0)
                {
                    projectile.ai[1] += 1f;
                }
            }
            if (projectile.ai[1] > shootCool)
            {
                projectile.ai[1] = 0f;
                projectile.netUpdate = true;
            }
            if (projectile.ai[0] == 0f)
            {
                if (target)
                {
                    /*if ((targetPos - projectile.Center).X > 0f)
                    {
                        projectile.spriteDirection = (projectile.direction = -1);
                    }
                    else if ((targetPos - projectile.Center).X < 0f)
                    {
                        projectile.spriteDirection = (projectile.direction = 1);
                    }*/
                    if (projectile.ai[1] == 0f)
                    {
                        projectile.ai[1] = 1f;
                        if (Main.myPlayer == projectile.owner)
                        {
                            Vector2 shootVel = targetPos - projectile.Center;
                            if (shootVel == Vector2.Zero)
                            {
                                shootVel = new Vector2(0f, 1f);
                            }
                            shootVel.Normalize();
                            shootVel *= shootSpeed;
                            int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootVel.X, shootVel.Y, shoot, projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
                            Main.projectile[proj].timeLeft = 300;
                            Main.projectile[proj].netUpdate = true;
                            projectile.rotation = (float)Math.Atan2((double)shootVel.Y, (double)shootVel.X);
                            projectile.netUpdate = true;
                        }
                    }
                }
            }
            projectile.netUpdate = true;
        }
    }
}