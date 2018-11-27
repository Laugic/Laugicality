using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic
{
	public class FreyaConjuration2 : ModProjectile
	{
        public int dir = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Freya Conjuration");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
		{
            dir = 0;
			projectile.width = 12;
			projectile.height = 12;
			//projectile.alpha = 255;
            projectile.timeLeft = 360;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = 2;
        }
		
		public override Color? GetAlpha(Color lightColor)
		{
			return ((Color.White * 0.5f) * (0.05f * projectile.timeLeft));
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //NPCs.Slybertron.Slybertron.electroShockHits += 1;
            int debuff = mod.BuffType("Spored");
            if (debuff >= 0)
            {
                target.AddBuff(debuff, 90, true);
            }      
        }
		
        public override void AI()
        {
			if (projectile.timeLeft == 359)
			{
				float num102 = 15f;
				int num103 = 0;
				while ((float)num103 < num102)
				{
					Vector2 vector12 = Vector2.UnitX * 0f;
					vector12 += -Vector2.UnitY.RotatedBy((double)((float)num103 * (6.28318548f / num102)), default(Vector2)) * new Vector2(2f, 6f);
					vector12 = vector12.RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
					int num104 = Dust.NewDust(projectile.Center, 0, 0, 56, 0f, 0f, 50, default(Color), 1f);
					Main.dust[num104].noGravity = true;
					Main.dust[num104].position = projectile.Center + vector12;
					Main.dust[num104].velocity = projectile.velocity * 0f + vector12.SafeNormalize(Vector2.UnitY) * 0.5f;
					int num = num103;
					num103 = num + 1;
				}
			}
			else
			{
				for (int k = 0; k < 2; k++)
				{
					int num234 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y) - projectile.velocity, projectile.width, projectile.height, 56, 0f, 0f, 50, default(Color), 0.75f);
					Dust dust3 = Main.dust[num234];
					dust3 = Main.dust[num234];
					dust3.velocity *= 0f;
					Main.dust[num234].noGravity = true;
				}
			}
			
            if(dir == 0)
            {
                
                if (Main.rand.Next(0, 2) == 0)
                    dir = -1;
                else
                    dir = 1;
            }
			if (projectile.velocity.Y < 2)
                projectile.velocity.Y += .1f;
            if(dir == 1)
            {
                if(Main.rand.Next(145) == 0)
                    dir = -1;
                if (projectile.velocity.X < 2)
                    projectile.velocity.X += .1f;
            }
            if (dir == -1)
            {
                if (Main.rand.Next(145) == 0)
                    dir = 1;
                if (projectile.velocity.X > -2)
                    projectile.velocity.X -= .1f;
            }
        }
		
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 56, Main.rand.Next((int)-2f, (int)2f), Main.rand.Next((int)-2f, (int)2f), 0, default(Color), 1f);
				Main.dust[dust].noGravity = true;
			}
		}
    }
}