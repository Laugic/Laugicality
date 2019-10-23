using System;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Thrown
{
    public class JetDaggerProjectile : ModProjectile
    {
        public int rot = 0;
        public int delay = 0;
        public bool reverse = false;
        public int vMax = 0;
        public float vAccel = 0;
        public float tVel = 0;
        public float vMag = 0;

        public override void SetDefaults()
        {
            vMax = 20;
            vAccel = .2f;
            reverse = false;
            delay = 100;
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = -1;
            projectile.aiStyle = 0;
            projectile.timeLeft = 600;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            projectile.velocity.Y += .1f;

            Vector2 delta = Main.player[projectile.owner].Center - projectile.Center;
            float dist = Vector2.Distance(Main.player[projectile.owner].Center, projectile.Center);
            if (reverse)
            {
                if (Main.rand.Next(4) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<White>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                projectile.tileCollide = false;
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
                    projectile.velocity = projectile.DirectionTo(Main.player[projectile.owner].Center) * vMag;
                }

                if (Math.Abs(delta.X) < 16 && Math.Abs(delta.Y) < 16)
                    projectile.Kill();
            }
            if(dist > 1800)
                projectile.Kill();
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            reverse = true;
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y;
            }
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            reverse = true;
        }
    }
}