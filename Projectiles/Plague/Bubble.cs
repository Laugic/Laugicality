using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Plague
{
	public class Bubble : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 120;
		}

		public override void AI()
		{
            if(projectile.velocity.Y > -6)
                projectile.velocity.Y -= .05f;
		}
        
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.damage > 0)
                target.AddBuff(mod.BuffType("Bubbly"), 4 * 60);
		}
	}
}