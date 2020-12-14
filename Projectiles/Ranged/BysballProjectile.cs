using Terraria;
using Terraria.ModLoader;
using Laugicality.Dusts;
using System;
using Microsoft.Xna.Framework;

namespace Laugicality.Projectiles.Ranged
{
    public class BysballProjectile : ModProjectile
    {
        int tileLife = 0;
        public override void SetDefaults()
        {
            LaugicalityVars.SnowballProjectiles.Add(projectile.type);
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 8;
            projectile.timeLeft = 3 * 60;
            tileLife = 0;
            projectile.tileCollide = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.velocity = oldVelocity;
            tileLife++;
            if (tileLife > 15)
                projectile.Kill();
            return false;
        }

        public override void AI()
        {
            projectile.velocity.Y += .3f;
            projectile.velocity.X *= .985f;
            if(Main.rand.Next(4) == 0)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<EtherialDust>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            var theta = (float)(Math.PI * Main.rand.NextDouble() * 2);
            var newVel = new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
            newVel *= 120;
            DrawDust(projectile.position, newVel, 20);
            projectile.position += newVel;
            newVel /= 120;
            newVel *= -12;
            projectile.velocity = newVel;
            base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
        }

        private void DrawDust(Vector2 position, Vector2 shift, int numDust)
        {
            for (int i = 0; i < numDust; i++)
            {
                Dust.NewDust(projectile.position + shift / numDust * i, projectile.width, projectile.height, ModContent.DustType<EtherialDust>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 50);
        }
    }
}