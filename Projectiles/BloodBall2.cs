using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class BloodBall2 : ModProjectile
	{
        
        public static bool kill = false;

		public override void SetDefaults()
		{
            kill = false;
			projectile.width = 10;
			projectile.height = 10;
			//projectile.alpha = 255;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 320;
		}

		public override void AI()
        {
            if (kill)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("BloodBoom"), projectile.damage, 3f, Main.myPlayer);
                projectile.Kill();
            }
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Rainbow"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }
        
    }
}