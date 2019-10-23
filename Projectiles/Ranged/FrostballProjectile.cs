using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Ranged
{
	public class FrostballProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.timeLeft = 600;
		}

		public override void AI()
		{
			projectile.velocity.Y += projectile.ai[0];
            projectile.ai[0] += 0.01f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Frost>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Frost>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
            return true;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 120 + Main.rand.Next(60));
        }
    }
}