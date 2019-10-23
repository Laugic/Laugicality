using System;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Destruction
{
	public class ZuesBoltDestruction2 : DestructionProjectile
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
                int newDust = Dust.NewDust(dustPos, 1, 1, 156, 0f, 0f, 150, default(Color), 1.75f);
                Main.dust[newDust].noGravity = true;
                Main.dust[newDust].position = dustPos;
                Dust dust3 = Main.dust[newDust];
                dust3.velocity *= 0.2f;
            }

            timer2++;
            if (timer2 > 5)
            {
                if (Main.myPlayer == projectile.owner)
                {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * Main.rand.NextFloat(-0.65f, -0.25f), projectile.velocity.Y * Main.rand.NextFloat(-0.65f, -0.25f), ModContent.ProjectileType<ZuesBoltDestruction3>(), (int)(projectile.damage * 0.5f), 2f, Main.myPlayer);
                }
                timer2 = 0;
            }

            timer++;
			if (timer > 4)
			{
				if (Main.myPlayer == projectile.owner)
				{
                    for (int i = 0; i < 15; i++)
                    {
						Vector2 vector12 = Vector2.UnitX * 0f;
						vector12 += -Vector2.UnitY.RotatedBy((double)((float)i * (6.28318548f / 15)), default(Vector2)) * new Vector2(5f, 10f);
						vector12 = vector12.RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
						int num104 = Dust.NewDust(projectile.Center, 0, 0, 228, 0f, 0f, 0, default(Color), 1.25f);
						Main.dust[num104].noGravity = true;
						Main.dust[num104].position = projectile.Center + vector12;
						Main.dust[num104].velocity = projectile.velocity * 0f + vector12.SafeNormalize(Vector2.UnitY) * 1f;
						int num = i;
						i = num + 1;
					}
				}
				timer = 0;
			}
        }
        
		public override void Kill(int timeLeft)
		{
			 for (int k = 0; k < 15; k++)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next((int)-10f, (int)10f), Main.rand.Next((int)-10f, (int)10f), ModContent.ProjectileType<ZuesBoltDestruction3>(), (int)(projectile.damage * 0.75f), 2f, projectile.owner, 1f, 0f);
			}
			for (int k = 0; k < 10; k++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, Main.rand.Next((int)-8f, (int)8f), Main.rand.Next((int)-8f, (int)8f), 100, default(Color), 1.25f);
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