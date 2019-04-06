using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
    public class YellowIceBall : ModProjectile
    {
        public int delay = 0;
        public override void SetDefaults()
        {
            delay = 0;
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.magic = true;
            //projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
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
            if(delay > 1 * 60)
                projectile.ai[0] += .01f;
        }

        public override void PostAI()
        {
            projectile.velocity.Y += projectile.ai[0];
        }
        
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 50);
        }
    }
}