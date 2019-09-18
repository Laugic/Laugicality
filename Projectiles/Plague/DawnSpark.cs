using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Plague
{
	public class DawnSpark : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = 4;
			projectile.timeLeft = 56;
            projectile.tileCollide = false;
        }

		public override void AI()
		{
			if(Main.rand.Next(4) == 0)Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Dawn"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            projectile.scale *= .95f;
            if (projectile.scale < .05f)
                projectile.Kill();
		}
        
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Dawn"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.damage > 0)
                target.AddBuff(mod.BuffType("Dawn"), 4 * 60 + Main.rand.Next(2 * 60));
		}
	}
}