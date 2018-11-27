using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic
{
	public class ZuesBoltDestruction1 : ModProjectile
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
			
			if (projectile.timeLeft < 178)
			{
				int num3;
				for (int num452 = 0; num452 < 5; num452 = num3 + 1)
				{
					Vector2 vector36 = projectile.Center;
					vector36 -= projectile.velocity * ((float)num452 * 0.25f);
					int num453 = Dust.NewDust(vector36, 1, 1, 159, 0f, 0f, 150, default(Color), 1.5f);
					Main.dust[num453].noGravity = true;
					Main.dust[num453].position = vector36;
					Dust dust3 = Main.dust[num453];
					dust3.velocity *= 0.2f;
					num3 = num452;
				}
			}
        }
        
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 8; k++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 159, Main.rand.Next((int)-4f, (int)4f), Main.rand.Next((int)-4f, (int)4f), 125, default(Color), 1f);
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