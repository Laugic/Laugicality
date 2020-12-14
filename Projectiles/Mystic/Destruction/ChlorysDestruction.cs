using System;

namespace Laugicality.Projectiles.Mystic.Destruction
{
    public class ChlorysDestruction : DestructionProjectile
    {
        int delay = 0;
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 120;
            projectile.ignoreWater = true;
            LaugicalityVars.SeedProjectiles.Add(projectile.type);
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            delay++;
            if (delay > 60)
            {
                projectile.ai[0] += .02f;
                projectile.velocity.Y += projectile.ai[0];
            }
        }
    }
}