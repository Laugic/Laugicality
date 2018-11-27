using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic
{
	public class DionysusExplosion : ModProjectile
    {
        public override void SetDefaults()
        {
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 64;
            projectile.height = 64;
			projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 26;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 9;
        }
		
		public override Color? GetAlpha(Color lightColor)
		{
			return ((Color.White * 0.75f) * (0.15f * projectile.timeLeft));
		}

        public override void AI()
        {
			if (projectile.timeLeft == 26)
			{
				float num102 = 15f;
				int num103 = 0;
				while ((float)num103 < num102)
				{
					Vector2 vector12 = Vector2.UnitX * 0f;
					vector12 += -Vector2.UnitY.RotatedBy((double)((float)num103 * (6.28318548f / num102)), default(Vector2)) * new Vector2(8f, 8f);
					vector12 = vector12.RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
					int num104 = Dust.NewDust(projectile.Center, 0, 0, 157, 0f, 0f, 150, default(Color), 1.5f);
					Main.dust[num104].noGravity = true;
					Main.dust[num104].position = projectile.Center + vector12;
					Main.dust[num104].velocity = -1 * (projectile.velocity * 0f + vector12.SafeNormalize(Vector2.UnitY) * 3.5f);
					int num = num103;
					num103 = num + 1;
				}
			}
        }
		
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 10; k++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 157, Main.rand.Next((int)-3f, (int)3f), Main.rand.Next((int)-3f, (int)-1f), 150, default(Color), 1f);
				Main.dust[dust].noGravity = true;
			}
		}
        
        public override void PostAI()
        {         
            projectile.frameCounter++;
            if (projectile.frameCounter > 3)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 9)
            {
                projectile.frame = 8;
                return;
            }
        }
    }
}