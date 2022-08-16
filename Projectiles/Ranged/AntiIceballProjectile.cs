using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Ranged
{
    public class AntiIceballProjectile : ModProjectile
    {
        int delay = 0;
        public override void SetDefaults()
        {
            LaugicalityVars.SnowballProjectiles.Add(projectile.type);
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.timeLeft = 300;
            projectile.tileCollide = true;
            delay = 0;
        }

        public override void AI()
        {
            delay++;
            if(delay > 10)
                projectile.velocity.Y -= .6f;
            projectile.velocity.X *= .975f;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 50);
        }
    }
}