using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Laugicality.Projectiles.SoulStone
{
	public class MiniEye : ModProjectile
    {
        public float delay = 4;

        public override void SetDefaults()
        {
            delay = 4;
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 3.14f;

            delay -= 1;
            if (delay <= 0)
            {
                delay = 4;
                for (int i = 0; i < 200; i++)
                {
                    NPC target = Main.npc[i];
                    if (!target.friendly)
                    {
                        float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                        float shootToY = target.position.Y - projectile.Center.Y;
                        float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                        if (distance < 480f && !target.friendly && target.active)
                        {
                            distance = 1f / distance;

                            shootToX *= distance * 5;
                            shootToY *= distance * 5;

                            if (projectile.velocity.X < shootToX)
                            {
                                projectile.velocity.X += (shootToX - projectile.velocity.X) / 6;
                            }
                            if (projectile.velocity.Y < shootToY)
                            {
                                projectile.velocity.Y += (shootToY - projectile.velocity.Y) / 6;
                            }
                            if (projectile.velocity.X > shootToX)
                            {
                                projectile.velocity.X -= (projectile.velocity.X - shootToX) / 6;
                            }
                            if (projectile.velocity.Y > shootToY)
                            {
                                projectile.velocity.Y -= (projectile.velocity.Y - shootToY) / 6;
                            }
                        }
                    }
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
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
    }
}