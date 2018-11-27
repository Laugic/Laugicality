using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic
{
	public class ZuesBoltIllusion1 : ModProjectile
    {
		public int timer = 0;
		
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
			projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.timeLeft = 120;
			projectile.friendly = true;
            projectile.ignoreWater = true;
			projectile.extraUpdates = 10;
		}

        public override void AI()
        {
			if (projectile.timeLeft < 178)
			{
				int num3;
				for (int num452 = 0; num452 < 5; num452 = num3 + 1)
				{
					Vector2 vector36 = projectile.Center;
					vector36 -= projectile.velocity * ((float)num452 * 0.25f);
					int num453 = Dust.NewDust(vector36, 1, 1, 169, 0f, 0f, 150, default(Color), 2.5f);
					Main.dust[num453].noGravity = true;
					Main.dust[num453].position = vector36;
					Dust dust3 = Main.dust[num453];
					dust3.velocity *= 0.2f;
					num3 = num452;
				}
			}
			
			timer++;
			if (timer > 8)
			{
				if (Main.myPlayer == projectile.owner)
				{
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * Main.rand.NextFloat(0.15f, 1.6f), projectile.velocity.Y * Main.rand.NextFloat(0.15f, 1.5f), mod.ProjectileType("ZuesBoltIllusion2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
				}
				timer = 0;
			}
        }
        
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 15; k++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 169, 0.85f * -projectile.velocity.X, 0.85f * -projectile.velocity.Y, 100, default(Color), 1.75f);
				Main.dust[dust].noGravity = true;
			}
		}
    }
}