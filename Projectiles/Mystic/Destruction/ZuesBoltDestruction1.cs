using System;
using Terraria;
using Microsoft.Xna.Framework;

namespace Laugicality.Projectiles.Mystic.Destruction
{
	public class ZuesBoltDestruction1 : DestructionProjectile
    {
		public int timer = 0;
		public int timer2 = 0;
		
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.penetrate = 1;
            projectile.timeLeft = 180;
			projectile.friendly = true;
            projectile.ignoreWater = true;
            Main.projFrames[projectile.type] = 5;
		}

        public override void AI()
        {
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            
            for (int i = 0; i < 5; i++)
            {
                Vector2 dustPos = projectile.Center;
                dustPos -= projectile.velocity * ((float)i * 0.25f);
                int newDust = Dust.NewDust(dustPos, 1, 1, 156, 0f, 0f, 150, default(Color), 1.5f);
                Main.dust[newDust].noGravity = true;
                Main.dust[newDust].position = dustPos;
                Dust dust3 = Main.dust[newDust];
                dust3.velocity *= 0.2f;
            }
        }
        
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 8; k++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, Main.rand.Next((int)-4f, (int)4f), Main.rand.Next((int)-4f, (int)4f), 125, default(Color), 1f);
				Main.dust[dust].noGravity = true;
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
            if (projectile.frame >= 5)
            {
                projectile.frame = 0;
                return;
            }
        }
    }
}