using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Laugicality.Projectiles
{
	public class TrueDawnSpark : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 256;
            projectile.tileCollide = false;
        }

		public override void AI()
		{
            if (Main.rand.Next(4) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Dawn"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            projectile.scale *= .95f;
            if (projectile.scale < .05f)
                projectile.Kill();
            projectile.rotation = projectile.timeLeft *(float)Math.PI / 10f;
        }
        
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 8; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Dawn"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.damage > 0)
                target.AddBuff(mod.BuffType("TrueDawn"), 6 * 60 + Main.rand.Next(6 * 60));
        }
    }
}