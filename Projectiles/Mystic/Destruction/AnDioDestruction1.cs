using System;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Destruction
{
    public class AnDioDestruction1 : DestructionProjectile
    {
        public bool stopped = false;
        public int delay = 0;
        public bool spawned = false;
        public float theta = 0;
        public float vel = 0;
        public bool zImmune = true;
        public float tVel = 0;
        public float distance = 0;
        public Vector2 origin;
        public Vector2 originV;
        public double mag = 10;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Loki Spiral");
        }
        public override void SetDefaults()
        {
            mag = 10;
            zImmune = true;
            theta = 0;
            vel = 0;
            stopped = false;
            spawned = false;
            projectile.width = 24;
            projectile.height = 24;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.timeLeft = 320;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

		public override Color? GetAlpha(Color lightColor)
		{
			return ((Color.White * 0.85f) * (0.1f * projectile.timeLeft));
		}

        public override void AI()
        {
			if (projectile.timeLeft == 320)
			{
				float num102 = 15f;
				int num103 = 0;
				while ((float)num103 < num102)
				{
					Vector2 vector12 = Vector2.UnitX * 0f;
					vector12 += -Vector2.UnitY.RotatedBy((double)((float)num103 * (6.28318548f / num102)), default(Vector2)) * new Vector2(2f, 6f);
					vector12 = vector12.RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
					int num104 = Dust.NewDust(projectile.Center, 0, 0, ModContent.DustType<Blue>(), 0f, 0f, 100, default(Color), 1f);
					Main.dust[num104].scale = 1.35f;
					Main.dust[num104].noGravity = true;
					Main.dust[num104].position = projectile.Center + vector12;
					Main.dust[num104].velocity = projectile.velocity * 0f + vector12.SafeNormalize(Vector2.UnitY) * 1f;
					int num = num103;
					num103 = num + 1;
				}
			}
			
            if(origin.X == 0)
            {
                origin.X = projectile.position.X;
                origin.Y = projectile.position.Y;
                originV.X = projectile.velocity.X;
                originV.Y = projectile.velocity.Y;
                if(Main.netMode != 1)
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X, projectile.velocity.Y, ModContent.ProjectileType<AnDioDestruction2>(), projectile.damage, 3, Main.myPlayer);
            }
            
			for (int k = 0; k < 2; k++)
            {
				int num234 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y) - projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Blue>(), 0f, 0f, 100, default(Color), 1f);
				Dust dust3 = Main.dust[num234];
				dust3 = Main.dust[num234];
				dust3.velocity *= 0.5f;
				Main.dust[num234].noGravity = true;
			}
			
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
            theta -= 3.14f / 30;
            mag += .75;
            origin += originV/5;
            double targetX = origin.X + mag * Math.Cos(theta + 3.14) - projectile.width / 2;
            double targetY = origin.Y + mag * Math.Sin(theta + 3.14);
            distance = (float)Math.Sqrt((targetX - projectile.position.X) * (targetX - projectile.position.X) + (targetY - projectile.position.Y) * (targetY - projectile.position.Y));
            tVel = distance / 6;
            projectile.netUpdate = true;
            if (vel < tVel)
            {
                vel += .2f;
                vel *= 1.1f;
            }
            if (vel > tVel)
            {
                vel -= .1f;
                vel *= .95f;
            }
            projectile.velocity.X = (float)Math.Abs((projectile.position.X - targetX) / distance * vel);
            if (targetX < projectile.position.X)
                projectile.velocity.X *= -1;
            projectile.velocity.Y = (float)Math.Abs((projectile.position.Y - targetY) / distance * vel);
            if (targetY < projectile.position.Y)
                projectile.velocity.Y *= -1;
        }
    }
}