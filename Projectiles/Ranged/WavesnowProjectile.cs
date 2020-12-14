using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Ranged
{
    public class WavesnowProjectile : ModProjectile
    {
        int delay = 0;
        bool spawned = false;
        public override void SetDefaults()
        {
            LaugicalityVars.SnowballProjectiles.Add(projectile.type);
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.timeLeft = 3 * 60;
            projectile.tileCollide = false;
            delay = 15;
            projectile.penetrate = -1;
            spawned = false;
        }

        public override void AI()
        {
            if(!spawned)
            {
                spawned = true;
                projectile.ai[0] = 1 - Main.rand.Next(2) * 2;
            }
            delay++;
            if (delay > 30)
            {
                delay = 0;
                projectile.ai[0] *= -1;
            }
            projectile.velocity.Y += .8f * projectile.ai[0];
            projectile.velocity.X *= .99f;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 50);
        }
    }
}