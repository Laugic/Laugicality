using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace Laugicality.Projectiles.Mystic.Destruction
{
    public class OrionDestruction : DestructionProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 80;
            projectile.height = 80;
            projectile.friendly = true;
            projectile.timeLeft = 256;
            projectile.tileCollide = false;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void AI()
        {
            if (Main.rand.Next(4) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("GalacticLight"));

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);


            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.velocity.X = 0f;
                projectile.velocity.Y = 0f;
                projectile.tileCollide = false;
                projectile.alpha = 255;
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                projectile.width = 120;
                projectile.height = 120;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            }
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item14, projectile.position);
            for (int k = 0; k < 18; k++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("White"));
                Main.dust[dust].noGravity = true;
            }
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 120;
            projectile.height = 120;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
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
    }
}