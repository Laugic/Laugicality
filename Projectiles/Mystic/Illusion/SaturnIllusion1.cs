using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Laugicality.Buffs;

namespace Laugicality.Projectiles.Mystic.Illusion
{
    public class SaturnIllusion1 : IllusionProjectile
    {
        int delay = 0;

        public override void SetDefaults()
        {
            delay = 0;
            projectile.width = 32;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 180;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.scale *= .85f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 8;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            buffID = mod.BuffType<OrbitalBuff>();
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

        public override void AI()
        {
            delay++;
            if(delay >= 12)
            {
                delay = 0;
                if ( Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -projectile.velocity.X / 2, -projectile.velocity.Y / 2, mod.ProjectileType("SaturnIllusion2"), projectile.damage, 3f, Main.myPlayer);
            }
        }
    }
}
