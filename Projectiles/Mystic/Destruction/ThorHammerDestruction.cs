using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Laugicality.Buffs;
using Terraria.ModLoader;
using System;

namespace Laugicality.Projectiles.Mystic.Destruction
{
    public class ThorHammerDestruction : DestructionProjectile
    {
        int delay = 0;

        public override void SetDefaults()
        {
            delay = 0;
            projectile.width = 74;
            projectile.height = 74;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 180;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            Main.projFrames[projectile.type] = 5;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor * 0.25f) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, new Rectangle(0, 74 * projectile.frame, 74, 74), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override void PostAI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 4)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 4)
            {
                projectile.frame = 0;
                return;
            }
        }

        public override void AI()
        {
            projectile.rotation += .2f;
            delay++;
            if(delay > 10)
            {
                if (Main.myPlayer == projectile.owner)
                {
                    projectile.velocity = Main.player[projectile.owner].Center - projectile.Center;
                    if (projectile.velocity.Length() < 40)
                        projectile.Kill();
                    projectile.velocity.Normalize();
                    projectile.velocity *= 36f;
                }
            }
        }
    }
}
