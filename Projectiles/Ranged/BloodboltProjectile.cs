using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Ranged
{
    public class BloodboltProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            LaugicalityVars.SnowballProjectiles.Add(projectile.type);
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.timeLeft = 300;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            projectile.velocity.Y += .9f;
            projectile.velocity.X *= .955f;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 50);
        }
    }
}