using System;
using Laugicality.Dusts;
using Terraria;
using Terraria.ModLoader;


namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class CupidHoming : ConjurationProjectile
    {
        public float mystDmg = 0;
        public float mystDur = 0;

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 200;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                if (!target.friendly)
                {
                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                    
                    if (distance < 480f && !target.friendly && target.active && target.damage > 0)
                    {
                        distance = 1f / distance;
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;
                        
                        int mag = 2;
                        if(projectile.velocity.X < shootToX)
                        {
                            projectile.velocity.X += (shootToX - projectile.velocity.X) / mag;
                        }
                        if(projectile.velocity.Y < shootToY)
                        {
                            projectile.velocity.Y += (shootToY - projectile.velocity.Y) / mag;
                        }
                        if (projectile.velocity.X > shootToX)
                        {
                            projectile.velocity.X -= (projectile.velocity.X - shootToX) / mag;
                        }
                        if (projectile.velocity.Y > shootToY)
                        {
                            projectile.velocity.Y -= (projectile.velocity.Y - shootToY) / mag;
                        }
                    }
                }
            }
            if(Main.rand.Next(4) == 0)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Pink>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }
    }
}