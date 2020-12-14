using System;
using Laugicality.Buffs;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
    public class ChlorysIllusion : IllusionProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = 4;
            projectile.timeLeft = 200;
            projectile.ignoreWater = true;
            projectile.scale *= 1f;
            buffID = ModContent.BuffType<Fertile>();
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + .785f;
            projectile.velocity.Y += projectile.ai[0] + .1f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                projectile.ai[0] += 0.1f;
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                projectile.velocity *= 0.8f;
            }
            return false;
        }
    }
}