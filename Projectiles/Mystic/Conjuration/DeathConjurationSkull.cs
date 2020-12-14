using Microsoft.Xna.Framework;
using Terraria;


namespace Laugicality.Projectiles.Mystic.Conjuration
{
    public class DeathConjurationSkull : ConjurationProjectile
    {
        public Color colorType;

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 120;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            projectile.velocity *= 0.95f;

            if (projectile.velocity.X > 0f)
            {
                projectile.rotation += 0.25f;
            }
            else
            {
                projectile.rotation -= 0.25f;
            }

            if (projectile.timeLeft < 20)
            {
                projectile.alpha += 8;
            }
        }
    }
}
