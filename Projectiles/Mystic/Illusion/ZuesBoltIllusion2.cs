using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
	public class ZuesBoltIllusion2 : IllusionProjectile
    {
		public int timer = 0;
		public float reduce = 0f;
        
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
			projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.timeLeft = 60;
			projectile.friendly = true;
            projectile.ignoreWater = true;
			projectile.extraUpdates = 10;
        }

        public override void AI()
        {
            int num3;
			for (int num452 = 0; num452 < 3; num452 = num3 + 1)
			{
				Vector2 vector36 = projectile.Center;
				vector36 -= projectile.velocity * ((float)num452 * 0.25f);
				projectile.alpha = 50;
				int num453 = Dust.NewDust(vector36, 1, 1, 156, 0f, 0f, 150, default(Color), 2.25f - reduce);
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
			
			timer++;
			if (timer > 2)
			{
				projectile.velocity.Y += Main.rand.NextFloat(-1.5f, 1.5f);
				projectile.velocity.X += Main.rand.NextFloat(-1.5f, 1.5f);
				timer = 0;
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