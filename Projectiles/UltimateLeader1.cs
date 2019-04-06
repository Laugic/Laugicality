using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using System;

namespace Laugicality.Projectiles
{

    public class UltimateLeader1 : HoverShooter
    {
        public int vMax = 0;
        public float vAccel = 0;
        public float tVel = 0; //Target Velocity
        public float vMag = 0;
        public int index = 0;
        public float theta = 0f;
        int reload = 0;
        int reloadMax = 45;

        public override void SetStaticDefaults()
        {
            reload = 0;
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            //ProjectileID.Sets.Homing[projectile.type] = true;
            //ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
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
            shootSpeed = 18f;
        }

        public override void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (player.dead)
            {
                modPlayer.uBois = false;
            }
            if (modPlayer.uBois)
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
                    int dust = Dust.NewDust(projectile.position, projectile.width / 2, projectile.height / 2, mod.DustType("White"));
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
                    int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("White"));
                    Main.dust[dust].velocity -= 1.2f * dustVel;
                }
            }
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
        }

        public override void Behavior()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Player player = Main.player[projectile.owner];
            if (index == 0)
                index = player.ownedProjectileCounts[mod.ProjectileType("UltimateLeader1")] + 1;
            float spacing = (float)projectile.width * spacingMult;
            projectile.tileCollide = false;
            theta = player.GetModPlayer<LaugicalityPlayer>(mod).theta + 3.14f / 4 * index;
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
                //vMag += vAccel;
                vMag = tVel;
            }

            if (vMag > tVel)
            {
                vMag = tVel;
            }

            if (dist != 0)
            {
                projectile.velocity = projectile.DirectionTo(targetPos) * vMag;
            }


            //Attack
            if(reload > 0)
                reload--;
            else
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("UltimateLeader4"), (int)(projectile.damage * 2), 3, Main.myPlayer);
                reload = reloadMax - 4 + Main.rand.Next(9);
            }

            projectile.netUpdate = true;


        }
    }
}