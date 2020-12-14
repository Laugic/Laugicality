using System;

namespace Laugicality.Projectiles.Mystic.Destruction
{
    public class AgnesDestruction2 : DestructionProjectile
    {
        int delay = 0;
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 90;
            projectile.ignoreWater = true;
            delay = 0;
            projectile.alpha = 255;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            delay++;
            if(delay > 18)
            {
                projectile.alpha = Math.Max(projectile.alpha - 20, 0);
            }
        }
    }
}