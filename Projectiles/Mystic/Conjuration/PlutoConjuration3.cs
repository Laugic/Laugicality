using System;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class PlutoConjuration3 : ConjurationProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.timeLeft = 100;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
        }
    }
}