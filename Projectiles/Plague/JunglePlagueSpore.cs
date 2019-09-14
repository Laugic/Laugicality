using Terraria.ModLoader;

namespace Laugicality.Projectiles.Plague
{
    public class JunglePlagueSpore : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 90;
        }

        public override void AI()
        {
            projectile.velocity *= .98f;
            projectile.alpha += 3;
            if (projectile.alpha > 250)
                projectile.Kill();
        }
    }
}