using Laugicality.Projectiles.Mystic.Misc;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class ThorShadowConjuration : ConjurationProjectile
    {
        int delay = 0;
        public override void SetDefaults()
        {
            projectile.width = 130;
            projectile.height = 130;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 10 * 60;
            Main.projFrames[projectile.type] = 4;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            projectile.rotation = 0;
            projectile.velocity *= .95f;
            delay++;
            if(delay >= 45)
            {
                delay = 0;
                if (Main.myPlayer == projectile.owner)
                {
                    //Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 122);
                    for (int i = 0; i < 6; i++)
                    {
                        double theta = Main.rand.NextDouble() * Math.PI * 2;
                        float mag = 12;
                        Projectile.NewProjectile(projectile.Center.X + 2 * mag * (float)Math.Cos(theta), projectile.Center.Y + 2 * mag * (float)Math.Sin(theta), (float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag, ModContent.ProjectileType<Bolt>(), (int)(projectile.damage), 8, Main.myPlayer);
                    }
                }
            }
        }
		
		public override void PostAI()
        {         
            projectile.frameCounter++;
            if (projectile.frameCounter > 4)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 3)
            {
                projectile.frame = 0;
                return;
            }
        }
    }
}