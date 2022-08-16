using System;
using Laugicality.Buffs;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
	public class MarsIllusion : IllusionProjectile
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mars' Illusion");
		}
        
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
            projectile.timeLeft = 300;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 3;
            buffID = ModContent.BuffType<Furious>();
        }

        public override void AI()
        {
            if (projectile.velocity.Y < 12)
                projectile.velocity.Y += .15f;
            if (Main.rand.Next(4) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Magma>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
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
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Magma>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
        }
    }
}