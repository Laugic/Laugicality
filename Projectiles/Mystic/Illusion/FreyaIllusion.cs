using System;
using Laugicality.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
	public class FreyaIllusion : IllusionProjectile
    {
		public bool shift = false;
		
        public override void SetDefaults()
        {
            projectile.width = 48;
            projectile.height = 48;
            projectile.friendly = true;
            projectile.penetrate = 8;
            projectile.timeLeft = 300;
            projectile.ignoreWater = true;
            Main.projFrames[projectile.type] = 2;
            buffID = ModContent.BuffType<Spored>();
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
            projectile.velocity.X *= .97f;
            projectile.velocity.Y *= .97f;
            
			if (Main.rand.Next(2) == 0)
			{
				int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 56, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 0, default(Color), 1.5f);
				Main.dust[DustID].noGravity = true;
			}

			projectile.rotation += 0.05f;
			if (projectile.timeLeft > 20)
			{
				if (!shift)
				{
					projectile.alpha += 2;
					projectile.scale += 0.0075f;
				}
				else
				{
					projectile.alpha -= 2;
					projectile.scale -= 0.0075f;
				}
				if (projectile.alpha > 175 && !shift)
				{
					shift = true;
				}
				if (projectile.alpha <= 25)
				{
					shift = false;
				}
			}
			else
			{
				projectile.alpha += 5;
			}
        }
		
		public override void PostAI()
        {         
            projectile.frameCounter++;
            if (projectile.frameCounter > 15)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 2)
            {
                projectile.frame = 0;
                return;
            }
        }
    }
}