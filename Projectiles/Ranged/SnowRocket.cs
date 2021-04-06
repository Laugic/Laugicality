using Terraria;
using Terraria.ModLoader;
using Laugicality.Dusts;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace Laugicality.Projectiles.Ranged
{
    public class SnowRocket : ModProjectile
    {
        int tileLife = 0;
        public override void SetDefaults()
        {
            LaugicalityVars.SnowballProjectiles.Add(projectile.type);
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 4 * 60;
            projectile.tileCollide = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.timeLeft = Math.Min(projectile.timeLeft, 2);
            projectile.ai[1] = 1;
            return false;
        }

        public override void AI()
        {
            projectile.velocity *= 1.02f;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);

            if (Main.rand.Next(4) == 0)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Smoke, -projectile.velocity.X * 0.1f, -projectile.velocity.Y * 0.1f);

            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 1 && projectile.ai[1] == 1)
            {
                if (Main.player[projectile.owner].active)
                {
                    var dist = Main.player[projectile.owner].Center - projectile.Center;
                    if (dist.Length() < 60)
                    {
                        var newVel = dist;
                        newVel.Normalize();
                        Main.player[projectile.owner].velocity += newVel * Math.Min(40 / Math.Max(dist.Length(), 1) * 12, 30);
                    }
                }
                projectile.velocity.X = 0f;
                projectile.velocity.Y = 0f;
                projectile.tileCollide = false;
                projectile.alpha = 255;
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                projectile.width = 96;
                projectile.height = 96;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            }
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            projectile.timeLeft = Math.Min(projectile.timeLeft, 2);
            projectile.ai[1] = 1;
            base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item14, projectile.position);
            for (int k = 0; k < 18; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 20, 0, 0);
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 217, 0, 0);
            }
        }
    }
}