using System;
using Laugicality.Projectiles.Thrown;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
    public class AgnesConjuration : PrimaryConjurationProjectile
    {
        int counter = 0;
        Vector2 oldVel;
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.aiStyle = 0;
            projectile.penetrate = -1;
            projectile.timeLeft = 8 * 60;
            projectile.tileCollide = true;
            counter = 0;
        }

        public override void AI()
        {
            if (projectile.velocity.Length() > .1f)
            {
                oldVel = projectile.velocity;
                oldVel.Normalize();
                oldVel *= 6;
                projectile.velocity *= .95f;
            }
            else
                projectile.velocity *= 0;
            projectile.rotation = (float)Math.Atan2((double)oldVel.Y, (double)oldVel.X) + 1.57f / 2f;
            Hail();
        }

        private void Hail()
        {
            counter++;
            if (counter > 30)
            {
                counter = 0;
                if(Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center, new Vector2(oldVel.X, oldVel.Y), ModContent.ProjectileType<AgnesConjuration2>(), projectile.damage, 0, projectile.owner);
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D13 = Main.projectileTexture[projectile.type];
            int imageHeight = Main.projectileTexture[projectile.type].Height;
            int y6 = imageHeight * projectile.frame;
            Main.spriteBatch.Draw(texture2D13, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, texture2D13.Width, imageHeight)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)texture2D13.Width / 2f, (float)imageHeight / 2f) + new Vector2(16, -16), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
    }
}