using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Laugicality.Dusts;

namespace Laugicality.Projectiles.Magic
{
    public class BysmalWand : ModProjectile
    {
        public bool bitherial = true;
        public bool stopped = false;
        public int power = 0;
        public int damage = 0;
        public int delay = 0;
        public bool spawned = false;
        public float theta = 0;
        public float vel = 0;
        public bool zImmune = true;
        public float tVel = 0;
        public float distance = 0;
        public Vector2 origin;
        public Vector2 originV;
        public double mag = 24;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bysmal Blast");
        }

        public override void SetDefaults()
        {
            mag = 24;
            zImmune = true;
            theta = 0;
            vel = 0;
            LaugicalityVars.eProjectiles.Add(projectile.type);
            power = 0;
            stopped = false;
            spawned = false;
            projectile.width = 16;
            projectile.height = 16;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.timeLeft = 320;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            if (origin.X == 0)
            {
                origin.X = projectile.position.X;
                origin.Y = projectile.position.Y;
                originV.X = projectile.velocity.X;
                originV.Y = projectile.velocity.Y;
            }
            bitherial = true;
            if(Main.rand.Next(8) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<EtherialDust>(), 0f, 0f);
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
            theta += 3.14f / 30 * projectile.ai[0];
            mag += .025;
            origin += originV / 5;
            double targetX = origin.X + mag * Math.Cos(theta + 3.14) - projectile.width / 2;
            double targetY = origin.Y + mag * Math.Sin(theta + 3.14);
            distance = (float)Math.Sqrt((targetX - projectile.position.X) * (targetX - projectile.position.X) + (targetY - projectile.position.Y) * (targetY - projectile.position.Y));
            tVel = distance / 6;
            projectile.netUpdate = true;
            if (vel < tVel)
            {
                vel += .2f;
                vel *= 1.1f;
            }
            if (vel > tVel)
            {
                vel = tVel;
            }
            projectile.velocity.X = (float)Math.Abs((projectile.position.X - targetX) / distance * vel);
            if (targetX < projectile.position.X)
                projectile.velocity.X *= -1;
            projectile.velocity.Y = (float)Math.Abs((projectile.position.Y - targetY) / distance * vel);
            if (targetY < projectile.position.Y)
                projectile.velocity.Y *= -1;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D13 = Main.projectileTexture[projectile.type];
            int imageHeight = Main.projectileTexture[projectile.type].Height;
            int y6 = imageHeight * projectile.frame;
            Main.spriteBatch.Draw(texture2D13, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, texture2D13.Width, imageHeight)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)texture2D13.Width / 2f, (float)imageHeight / 2f) + new Vector2(6, -6), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
    }
}