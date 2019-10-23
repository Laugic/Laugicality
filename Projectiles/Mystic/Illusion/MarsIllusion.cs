using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
	public class MarsIllusion : IllusionProjectile
    {
        public int delay = 0;

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mars' Illusion");
		}

		public override void SetDefaults()
		{
            delay = 0;
			projectile.width = 16;
			projectile.height = 16;
            projectile.timeLeft = 180;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = 3;
            buffID = ModContent.BuffType("Furious");
        }

        public override void AI()
        {
            if (Main.myPlayer == projectile.owner && projectile.timeLeft < 170)
            {
                Vector2 vec;
                vec.X = Main.MouseWorld.X;
                vec.Y = Main.MouseWorld.Y;

                float mag = 7.5f;
                
                float diffX = vec.X - projectile.Center.X;
                float diffY = vec.Y - projectile.Center.Y;
                float dist = (float)Math.Sqrt((double)(diffX * diffX + diffY * diffY));
                dist = mag / dist;
                diffX *= dist;
                diffY *= dist;

                projectile.velocity.X = (projectile.velocity.X * 20f + diffX) / 21f;
                projectile.velocity.Y = (projectile.velocity.Y * 20f + diffY) / 21f;
            }
        }
    }
}