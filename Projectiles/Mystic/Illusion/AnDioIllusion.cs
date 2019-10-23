using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
    public class AnDioIllusion : IllusionProjectile
    {
        public int delay = 4;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ande Laser");
        }

        public override void SetDefaults()
        {
            delay = 4;
            projectile.width = 22;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 120;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            buffID = BuffID.Chilled;
        }
		
		public override Color? GetAlpha(Color lightColor)
		{
			return ((Color.White * 0.45f) * (0.05f * projectile.timeLeft));
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = Color.White * 0.15f;
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
        
        public override void AI()
        {
            for (int k = 0; k < 1; k++)
            {
				int num234 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y) - projectile.velocity, projectile.width, projectile.height, ModContent.DustType("Blue"), 0f, 0f, 125, default(Color), 1f);
				Dust dust3 = Main.dust[num234];
				dust3 = Main.dust[num234];
				dust3.velocity *= 0.65f;
				Main.dust[num234].noGravity = true;
			}
			
            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 1400f;
            bool target = false;
            for (int i = 0; i < 200; i++)
                {
                    NPC npcT = Main.npc[i];
                    //If the npc is hostile
                    if (!npcT.friendly)
                    {
                        Vector2 newMove = npcT.Center - projectile.Center;
                        float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                        if (distanceTo < distance)
                        {
                            move = newMove;
                            distance = distanceTo;
                            target = true;
                        }
                    }
                }
            if (target)
            {
                AdjustMagnitude(ref move);
                projectile.velocity = (10 * projectile.velocity + move) / 11f;
                AdjustMagnitude(ref projectile.velocity);
                projectile.velocity *=3;
            }

            projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }
    }
}