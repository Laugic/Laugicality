using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class Frostball : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.magic = true;
			//projectile.penetrate = 1;
			projectile.timeLeft = 600;
		}

		public override void AI()
		{
			projectile.velocity.Y += projectile.ai[0];
            projectile.ai[0] += 0.01f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Frost"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Frost"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Frost"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

        }

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
            return true;
		}
        
        
	}
}