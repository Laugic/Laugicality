using Microsoft.Xna.Framework;
using Terraria;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class FreyaConjuration2 : ConjurationProjectile
    {
        public int dir = 0;
        bool justSpawned = false;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Freya Conjuration");
		}

		public override void SetDefaults()
		{
            dir = 0;
            justSpawned = false;
            projectile.width = 12;
			projectile.height = 12;
            projectile.timeLeft = 360;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = 2;
            LaugicalityVars.ShroomProjectiles.Add(projectile.type);
        }
		
		public override Color? GetAlpha(Color lightColor)
		{
			return ((Color.White * 0.5f) * (0.05f * projectile.timeLeft));
		}
		
        public override void AI()
        {
			if (!justSpawned)
			{
                justSpawned = true;
				for (int i = 0; i < 15; i++)
				{
					Vector2 vector12 = Vector2.UnitX * 0f;
					vector12 += -Vector2.UnitY.RotatedBy((double)((float)i * (6.28318548f / 15)), default(Vector2)) * new Vector2(2f, 6f);
					vector12 = vector12.RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
					int newDust = Dust.NewDust(projectile.Center, 0, 0, 56, 0f, 0f, 50, default(Color), 1f);
					Main.dust[newDust].noGravity = true;
					Main.dust[newDust].position = projectile.Center + vector12;
					Main.dust[newDust].velocity = projectile.velocity * 0f + vector12.SafeNormalize(Vector2.UnitY) * 0.5f;
				}
			}
			else
			{
				for (int k = 0; k < 2; k++)
				{
					int newDust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y) - projectile.velocity, projectile.width, projectile.height, 56, 0f, 0f, 50, default(Color), 0.75f);
					Dust dust3 = Main.dust[newDust];
					dust3 = Main.dust[newDust];
					dust3.velocity *= 0f;
					Main.dust[newDust].noGravity = true;
				}
			}
			
            if(dir == 0)
            {
                
                if (Main.rand.Next(0, 2) == 0)
                    dir = -1;
                else
                    dir = 1;
            }
			if (projectile.velocity.Y < 2)
                projectile.velocity.Y += .1f;
            if(dir == 1)
            {
                if(Main.rand.Next(145) == 0)
                    dir = -1;
                if (projectile.velocity.X < 2)
                    projectile.velocity.X += .1f;
            }
            if (dir == -1)
            {
                if (Main.rand.Next(145) == 0)
                    dir = 1;
                if (projectile.velocity.X > -2)
                    projectile.velocity.X -= .1f;
            }
        }
		
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 56, Main.rand.Next((int)-2f, (int)2f), Main.rand.Next((int)-2f, (int)2f), 0, default(Color), 1f);
				Main.dust[dust].noGravity = true;
			}
		}
    }
}