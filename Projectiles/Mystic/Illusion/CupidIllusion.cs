using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
	public class CupidIllusion : IllusionProjectile
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heartburn Arrow");     
		}

		public override void SetDefaults()
        {
            projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ranged = true;
			projectile.penetrate = 2;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
            buffID = ModContent.BuffType("Lovestruck");
        }
    }
}
