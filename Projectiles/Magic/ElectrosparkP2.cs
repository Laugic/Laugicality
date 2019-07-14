using Terraria.ModLoader;

namespace Laugicality.Projectiles.Magic
{
	public class ElectrosparkP2 : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electrospark");
		}

		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 48;
            projectile.timeLeft = 80;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = 4;
        }
    }
}