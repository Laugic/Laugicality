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
	public class DionysusIllusion : ModProjectile
    {
        public int damage = 0;
        public bool powered = false;
        public int power = 1;
        public float mystDur = 0f;

        public override void SetDefaults()
        {
            power = 1;
            powered = false;
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 100;
            projectile.ignoreWater = true;
            projectile.scale *= 1.15f;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor * 0.25f) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(70, (int)(140 * mystDur * power)); //Venom
            //if (target.GetGlobalNPC<LaugicalGlobalNPCs>(mod).mysticDamage < mystDmg)target.GetGlobalNPC<LaugicalGlobalNPCs>(mod).mysticDamage = mystDmg;
        }
		
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (!powered)
            {
                powered = true;
                while (modPlayer.illusionPower > power)
                {
                    power++;
                }
            }
            mystDur = modPlayer.mysticDuration;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            //Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Hades"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

        }
		
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 40, 0.1f * -projectile.velocity.X, 0.1f * -projectile.velocity.Y, 100, default(Color), 1f);
				Main.dust[dust].noGravity = true;
			}
		}
    }
}