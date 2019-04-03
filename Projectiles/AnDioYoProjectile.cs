using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class AnDioYoProjectile : ModProjectile
    {
        public int reload = 60;
        public override void SetStaticDefaults()
		{
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 9f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 280f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 14f;
		}

		public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
            reload = 60;
		}

        public Vector2 getPosition()
        {
            return projectile.position;
        }

		public override void PostAI()
        {
            reload -= 1;
            if (reload <= 0)
            {
                reload = 30;
                if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 4 - Main.rand.Next(8), 4 - Main.rand.Next(8), mod.ProjectileType("AnDioYoShot"), projectile.damage, 3f, Main.myPlayer);
            }
        }
	}
}
