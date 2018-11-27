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
	public class ZuesBoltDestruction2 : ModProjectile
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
					int num453 = Dust.NewDust(vector36, 1, 1, 169, 0f, 0f, 150, default(Color), 1.75f);
					Main.dust[num453].noGravity = true;
					Main.dust[num453].position = vector36;
					Dust dust3 = Main.dust[num453];
					dust3.velocity *= 0.2f;
					num3 = num452;
				}
				
				timer2++;
				if (timer2 > 5)
				{
					if (Main.myPlayer == projectile.owner)
					{
						Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * Main.rand.NextFloat(-0.65f, -0.25f), projectile.velocity.Y * Main.rand.NextFloat(-0.65f, -0.25f), mod.ProjectileType("ZuesBoltDestruction3"), (int)(projectile.damage * 0.5f), 2f, Main.myPlayer);
					}
					timer2 = 0;
				}
			}
			
			timer++;
			if (timer > 4)
			{
				if (Main.myPlayer == projectile.owner)
				{
					float num102 = 15f;
					int num103 = 0;
					while ((float)num103 < num102)
					{
						Vector2 vector12 = Vector2.UnitX * 0f;
						vector12 += -Vector2.UnitY.RotatedBy((double)((float)num103 * (6.28318548f / num102)), default(Vector2)) * new Vector2(5f, 10f);
						vector12 = vector12.RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
						int num104 = Dust.NewDust(projectile.Center, 0, 0, 228, 0f, 0f, 0, default(Color), 1.25f);
						Main.dust[num104].noGravity = true;
						Main.dust[num104].position = projectile.Center + vector12;
						Main.dust[num104].velocity = projectile.velocity * 0f + vector12.SafeNormalize(Vector2.UnitY) * 1f;
						int num = num103;
						num103 = num + 1;
					}
				}
				timer = 0;
			}
        }
        
		public override void Kill(int timeLeft)
		{
			 for (int k = 0; k < 15; k++)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next((int)-10f, (int)10f), Main.rand.Next((int)-10f, (int)10f), mod.ProjectileType("ZuesBoltDestruction3"), (int)(projectile.damage * 0.75f), 2f, projectile.owner, 1f, 0f);
			}
			for (int k = 0; k < 10; k++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 169, Main.rand.Next((int)-8f, (int)8f), Main.rand.Next((int)-8f, (int)8f), 100, default(Color), 1.25f);
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