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
	public class ZuesBoltDestruction3 : ModProjectile
    {
		public int timer = 0;
		public float reduce = 0f;
	
		public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
			projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.timeLeft = 20;
			projectile.friendly = true;
            projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}

        public override void AI()
        {
            int num3;
			for (int num452 = 0; num452 < 3; num452 = num3 + 1)
			{
				Vector2 vector36 = projectile.Center;
				vector36 -= projectile.velocity * ((float)num452 * 0.25f);
				projectile.alpha = 50;
				int num453 = Dust.NewDust(vector36, 1, 1, 169, 0f, 0f, 150, default(Color), 1.75f - reduce);
				Main.dust[num453].noGravity = true;
				Main.dust[num453].position = vector36;
				Dust dust3 = Main.dust[num453];
				dust3.velocity *= 0.2f;
				num3 = num452;
			}
			
			if (reduce < 2f)
			{
				reduce += 0.025f;
			}
			
			if (projectile.ai[0] == 1f)
			{
				projectile.extraUpdates = 2;
				timer++;
				if (timer > 1)
				{
					projectile.velocity.Y += Main.rand.NextFloat(-3f, 3f);
					projectile.velocity.X += Main.rand.NextFloat(-3f, 3f);
					timer = 0;
				}
			}
			else
			{
				projectile.extraUpdates = 4;
				timer++;
				if (timer > 2)
				{
					projectile.velocity.Y += Main.rand.NextFloat(-1.15f, 1.15f);
					projectile.velocity.X += Main.rand.NextFloat(-1.15f, 1.15f);
					timer = 0;
				}
			}
        }
        
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 169, 0.5f * -projectile.velocity.X, 0.5f * -projectile.velocity.Y, 100, default(Color), 0.5f);
				Main.dust[dust].noGravity = true;
			}
		}
    }
}