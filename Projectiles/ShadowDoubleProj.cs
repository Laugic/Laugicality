using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Microsoft.Xna.Framework.Graphics;
using Laugicality.Dusts;

namespace Laugicality.Projectiles
{
    public class ShadowDoubleProj : ModProjectile
    {
        float theta = 0;
        bool collided = false;

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 26;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 10 * 60;
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
                Color color = Color.White * 0.15f;
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override void AI()
        {
            for(int i = 0; i < 2; i++)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType<Black>(), 0, -Main.rand.NextFloat() * 2 - 2);

            float dist = Vector2.Distance(Main.player[projectile.owner].Center, projectile.Center);
            if(dist != 0)
            {
                float tVel = dist / 25;
                projectile.velocity = projectile.DirectionTo(Main.player[projectile.owner].Center) * tVel;
            }
            if (projectile.velocity.X > 0)
                projectile.spriteDirection = -1;
            else
                projectile.spriteDirection = 1;
        }
    }
}