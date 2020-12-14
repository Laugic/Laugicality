using System;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
    public class AnDioStalactite : ConjurationProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Loki Stalactite");
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 60;
            projectile.timeLeft = 120;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 2;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            projectile.velocity.Y = Math.Min(10, projectile.velocity.Y + .6f);
        }
    }
}