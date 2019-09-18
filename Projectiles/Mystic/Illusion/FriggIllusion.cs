using System;
using Terraria.ID;

namespace Laugicality.Projectiles.Mystic.Illusion
{
	public class FriggIllusion : IllusionProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
			projectile.aiStyle = -1;
			projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.timeLeft = 120;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            buffID = BuffID.Poisoned;
        }

        public override void AI()
        {
			if (projectile.timeLeft > 20 && projectile.alpha > 0)
			{
				projectile.alpha -= 15;
			}
			else
			{
				projectile.alpha += 15;
			}
			
			if (projectile.velocity.X > 0f)
			{
				projectile.rotation += 0.08f;
			}
			else
			{
				projectile.rotation -= 0.08f;
			}
			
            if (Math.Abs(projectile.velocity.X) <= 10f && Math.Abs(projectile.velocity.Y) <= 10f)
            {
                projectile.velocity.X *= 1.01f;
                projectile.velocity.Y *= 1.01f;
            }
        }
    }
}