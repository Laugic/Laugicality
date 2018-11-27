using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Laugicality.Projectiles.Mystic
{
	public class HallowsEveDestruction2 : ModProjectile
    {
        public int damage = 0;
        public bool powered = false;
        public int power = 1;
        public float mystDur = 0f;

        public override void SetDefaults()
        {
            power = 1;
            powered = false;
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 120;
            projectile.ignoreWater = true;
			projectile.tileCollide = false;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 6;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor * 0.35f) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				if (projectile.velocity.X < 0f)
				{
					spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
				}
				else
				{
					spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.FlipHorizontally, 0f);
				}
			}
			return true;
		}
		
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            
			if (projectile.timeLeft == 120)
			{
				float num102 = 20f;
				int num103 = 0;
				while ((float)num103 < num102)
				{
					Vector2 vector12 = Vector2.UnitX * 0f;
					vector12 += -Vector2.UnitY.RotatedBy((double)((float)num103 * (6.28318548f / num102)), default(Vector2)) * new Vector2(3f, 8f);
					vector12 = vector12.RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
					int num104 = Dust.NewDust(projectile.Center, 0, 0, 111, 0f, 0f, 75, default(Color), 1f);
					Main.dust[num104].noGravity = true;
					Main.dust[num104].position = projectile.Center + vector12;
					Main.dust[num104].velocity = projectile.velocity * 0f + vector12.SafeNormalize(Vector2.UnitY) * 1f;
					int num = num103;
					num103 = num + 1;
				}
			}
			
			for (int num363 = 0; num363 < 2; num363++)
			{
				float num364 = projectile.velocity.X / 2.5f * (float)num363;
				float num365 = projectile.velocity.Y / 2.5f * (float)num363;
				int num366 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 111, 0f, 0f, 75, default(Color), 0.75f);
				Main.dust[num366].position.X = projectile.Center.X - num364;
				Main.dust[num366].position.Y = projectile.Center.Y - num365;
				Main.dust[num366].velocity *= 0f;
				Main.dust[num366].noGravity = true;
			}
			
			if (projectile.velocity.X > 0f)
			{
				projectile.spriteDirection = -1;
			}
			else
			{
				projectile.spriteDirection = 1;
			}
			
			if (Main.myPlayer == projectile.owner && projectile.timeLeft < 170)
            {
				Vector2 vec;
				vec.X = Main.MouseWorld.X;
				vec.Y = Main.MouseWorld.Y;
				
				float num488 = 7.5f;
				
				Vector2 vector38 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float num489 = vec.X - vector38.X;
				float num490 = vec.Y - vector38.Y;
				float num491 = (float)Math.Sqrt((double)(num489 * num489 + num490 * num490));
				num491 = num488 / num491;
				num489 *= num491;
				num490 *= num491;
				
				projectile.velocity.X = (projectile.velocity.X * 20f + num489) / 21f;
				projectile.velocity.Y = (projectile.velocity.Y * 20f + num490) / 21f;
			}
        }
		
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 10; k++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 111, Main.rand.Next((int)-3f, (int)3f), Main.rand.Next((int)-3f, (int)3f), 75, default(Color), 0.75f);
				Main.dust[dust].noGravity = true;
			}
		}
    }
}