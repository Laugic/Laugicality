using System;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class Dart : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.Homing[projectile.type] = true;
			ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 34;
			projectile.height = 10;
			projectile.penetrate = 3;
			projectile.friendly = true;
			projectile.ignoreWater = true;
		}

		public override void AI()
        {
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
            //projectile.velocity.Y += projectile.ai[0];
		}
    }
}