using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Destruction
{
	public class MarsDestruction : DestructionProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 30;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.scale = 1.5f;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2;
        }
    }
}