using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Destruction
{
	public class DionysusDestruction : DestructionProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 180;
            projectile.ignoreWater = true;
            projectile.scale = 2f;
        }
		
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 20;
			height = 20;
			return true;
		}

        public override void AI()
        {
            projectile.velocity.Y += .4f;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + .785f;
        }

		public override void Kill(int timeLeft)
		{
			if (Main.myPlayer == projectile.owner)
			{
               Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, ModContent.ProjectileType<DionysusExplosion>(), (int)projectile.damage, 3f, Main.myPlayer);
			}
		}
    }
}