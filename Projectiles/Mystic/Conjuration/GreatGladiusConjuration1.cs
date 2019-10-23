using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class GreatGladiusConjuration1 : ConjurationProjectile
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Great Gladius Conjuration");
		}

		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 2;
            projectile.timeLeft = 6 * 60;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
        }
        
        public override void AI()
        {
            if (Main.rand.Next(4) == 0)
            {
                if (Main.netMode != 1)
                    Projectile.NewProjectile(projectile.Center.X - 64, projectile.Center.Y, -4 + Main.rand.Next(9), -Main.rand.Next(6, 9), ModContent.ProjectileType<GreatGladiusConjuration2>(), (int)(projectile.damage) / 4, 3, Main.myPlayer);
            }
        }
    }
}