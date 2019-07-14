using Terraria.ModLoader;

namespace Laugicality.Projectiles.Special
{
	public class Nothing : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 6;
			projectile.height = 6;
			projectile.aiStyle = 0;
			projectile.scale = 1f;
			projectile.penetrate = 1;
			projectile.timeLeft = 2;
			projectile.tileCollide = false;
            projectile.friendly = false;
		}
	}
}