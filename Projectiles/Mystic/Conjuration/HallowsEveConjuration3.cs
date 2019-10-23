using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class HallowsEveConjuration3 : ConjurationProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 180;
            projectile.ignoreWater = true;
			projectile.tileCollide = true;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor * 0.4f) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
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
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            
			for (int k = 0; k < 2; k++)
            {
				int num234 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y) - projectile.velocity, projectile.width, projectile.height, 6, 0f, 0f, 125, default(Color), 1.5f);
				Dust dust3 = Main.dust[num234];
				dust3 = Main.dust[num234];
				dust3.velocity *= 0.15f;
				Main.dust[num234].noGravity = true;
			}
			
			projectile.velocity.Y += 0.5f;
			
			if (projectile.velocity.X > 0f)
			{
				projectile.rotation += 0.15f;
				projectile.spriteDirection = 1;
			}
			else
			{
				projectile.rotation -= 0.15f;
				projectile.spriteDirection = -1;
			}
			
			if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
			{
				projectile.velocity.X = 0f;
				projectile.velocity.Y = 0f;
				projectile.tileCollide = false;
				projectile.alpha = 255;
				projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
				projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
				projectile.width = 50;
				projectile.height = 50;
				projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
				projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			}
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.timeLeft = 4;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.timeLeft = 4;
			return true;
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item14, projectile.position);
			// Smoke Dust spawn
			for (int i = 0; i < 15; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			// Fire Dust spawn
			for (int i = 0; i < 20; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 127, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
				dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 127, 0f, 0f, 100, default(Color), 1f);
				Main.dust[dustIndex].velocity *= 3f;
			}
			// Large Smoke Gore spawn
			for (int g = 0; g < 2; g++)
			{
				int goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 0.6f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 0.75f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 0.75f;
				goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 0.8f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 0.75f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 0.75f;
				goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 0.6f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 0.75f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 0.75f;
				goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 0.8f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 0.75f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 0.75f;
			}
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 26;
			projectile.height = 26;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
		}
    }
}