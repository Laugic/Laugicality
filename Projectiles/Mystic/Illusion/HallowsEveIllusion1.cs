using System;
using Laugicality.Buffs;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
    public class HallowsEveIllusion1 : IllusionProjectile
    {
        public float theta = 0;
		public int timer = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallow's Eve Illusion");
        }

        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.timeLeft = 300;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            buffID = ModContent.BuffType<SpookedBuff>();
        }
		/*
		public override Color? GetAlpha(Color lightColor)
		{
            return ((Color.White * 0.0f) * (0.025f * projectile.timeLeft));
		}*/

        public override void AI()
        {
			Vector2 origin = projectile.Center;
			theta -= 3.14f / 20;

            for (int i = 0; i < 2; i++)
            {
			    double targetX = origin.X + Math.Cos(theta + i * 3.14f / 1) * 10;
			    double targetY = origin.Y + Math.Sin(theta + i * 3.14f / 1) * 10;
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 0, default(Color), 2.25f);
				Main.dust[dust].position.X = (float)targetX;
				Main.dust[dust].position.Y = (float)targetY;
				Main.dust[dust].velocity *= 0f;
				Main.dust[dust].noGravity = true;
			}
			
			timer++;
			if (timer > 8)
			{
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, -1f), ModContent.ProjectileType<HallowsEveIllusion2>(), (int)(projectile.damage * 0.35f), 1f, Main.myPlayer);
				timer = 0;
			}
        }
		
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 2; k++)
			{
				for(int i = 0; i < 20; i++)
				{
					Vector2 theta2 = Vector2.UnitX * 0f;
					theta2 += -Vector2.UnitY.RotatedBy((double)((float)i * (6.28318548f / 20)), default(Vector2)) * new Vector2(8f, 8f);
					theta2 = theta2.RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
					int dust = Dust.NewDust(projectile.Center, 0, 0, 6, 0f, 0f, 0, default(Color), 1.25f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].position = projectile.Center + theta2;
					Main.dust[dust].velocity = projectile.velocity * 0f + theta2.SafeNormalize(Vector2.UnitY) * 1.25f;
				}
			}
		}
    }
}