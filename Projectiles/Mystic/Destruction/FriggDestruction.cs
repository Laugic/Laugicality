using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic.Destruction
{
	public class FriggDestruction : DestructionProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 200;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            if (projectile.velocity.X > 0f)
			{
				projectile.rotation += 0.1f;
			}
			else
			{
				projectile.rotation -= 0.1f;
			}
        }
        
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 44, 0.1f * -projectile.velocity.X, 0.1f * -projectile.velocity.Y, 150, default(Color), 1f);
				Main.dust[dust].noGravity = true;
			}
		}
    }
}