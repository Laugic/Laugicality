using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class ElectrosparkP2 : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electrospark");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 48;
			//projectile.alpha = 255;
            projectile.timeLeft = 80;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = 4;
        }
    }
}