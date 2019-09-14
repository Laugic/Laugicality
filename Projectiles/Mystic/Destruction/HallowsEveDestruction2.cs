using System;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Laugicality.Projectiles.Mystic.Destruction
{
	public class HallowsEveDestruction2 : DestructionProjectile
    {
        bool justSpawned = false;
        int delay = 0;
        public override void SetDefaults()
        {
            delay = 0;
            justSpawned = false;
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
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            
			if (!justSpawned)
			{
                justSpawned = true;
				for (int i = 0; i < 20; i++)
				{
					Vector2 dustPos = Vector2.UnitX * 0f;
					dustPos += -Vector2.UnitY.RotatedBy((double)((float)i * (6.28318548f / 20)), default(Vector2)) * new Vector2(3f, 8f);
					dustPos = dustPos.RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
					int dust = Dust.NewDust(projectile.Center, 0, 0, 111, 0f, 0f, 75, default(Color), 1f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].position = projectile.Center + dustPos;
					Main.dust[dust].velocity = projectile.velocity * 0f + dustPos.SafeNormalize(Vector2.UnitY) * 1f;
				}
			}
			
			for (int i = 0; i < 2; i++)
			{
				float speedX = projectile.velocity.X / 2.5f * (float)i;
				float speedY = projectile.velocity.Y / 2.5f * (float)i;
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 111, 0f, 0f, 75, default(Color), 0.75f);
				Main.dust[dust].position.X = projectile.Center.X - speedX;
				Main.dust[dust].position.Y = projectile.Center.Y - speedY;
				Main.dust[dust].velocity *= 0f;
				Main.dust[dust].noGravity = true;
			}
			
			if (projectile.velocity.X > 0f)
			{
				projectile.spriteDirection = -1;
			}
			else
			{
				projectile.spriteDirection = 1;
			}
            delay++;
            if (Main.myPlayer == projectile.owner && delay > 10)
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