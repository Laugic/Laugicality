using Microsoft.Xna.Framework;
using System;

namespace Laugicality.Projectiles.Mystic.Destruction
{
    public class CharonDestruction : DestructionProjectile
    {
        int delay = 0;
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 120;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            projectile.rotation += projectile.velocity.X / 40;

            projectile.velocity.Y += .4f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y;
            }
            projectile.velocity.Y += .1f;
            projectile.velocity *= 0.9f;
            return false;
        }
    }
}