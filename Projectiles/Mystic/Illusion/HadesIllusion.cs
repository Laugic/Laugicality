using System;
using Laugicality.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
	public class HadesIllusion : IllusionProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 100;
            projectile.ignoreWater = true;
            projectile.scale *= 1.5f;
            buffID = BuffID.ShadowFlame;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + .785f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Hades>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }
    }
}