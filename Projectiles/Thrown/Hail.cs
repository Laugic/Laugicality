using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Laugicality.Dusts;

namespace Laugicality.Projectiles.Thrown
{
    public class Hail : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 120;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2;
            if (Main.rand.Next(5) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType<EtherialDust>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            projectile.ai[0] += .01f;
            projectile.velocity.Y += projectile.ai[0];
            projectile.velocity.X *= .98f;
        }
    }
}