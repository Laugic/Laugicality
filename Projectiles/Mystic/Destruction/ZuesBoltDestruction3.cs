using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic.Destruction
{
	public class ZuesBoltDestruction3 : DestructionProjectile
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
			for (int i = 0; i < 3; i++)
			{
				Vector2 dustPos = projectile.Center;
				dustPos -= projectile.velocity * ((float)i * 0.25f);
				projectile.alpha = 50;
				int newDust = Dust.NewDust(dustPos, 1, 1, 156, 0f, 0f, 150, default(Color), 1.75f - reduce);
				Main.dust[newDust].noGravity = true;
				Main.dust[newDust].position = dustPos;
				Dust dust3 = Main.dust[newDust];
				dust3.velocity *= 0.2f;
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
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, 0.5f * -projectile.velocity.X, 0.5f * -projectile.velocity.Y, 100, default(Color), 0.5f);
				Main.dust[dust].noGravity = true;
			}
		}
    }
}