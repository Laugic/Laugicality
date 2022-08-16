using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Laugicality.Buffs;
using Laugicality.Dusts;

namespace Laugicality.Projectiles.Ranged
{
    public class BigSnowballProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            LaugicalityVars.SnowballProjectiles.Add(projectile.type);
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 300;
            projectile.ranged = true;
            projectile.ignoreWater = true;
        }


        public override void AI()
        {
            projectile.velocity.Y += .4f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 33, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 33, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 50);
            return false;
        }
        public override void Kill(int timeLeft)
        {
            int shards = Main.rand.Next(2, 5);
            if (projectile.ai[0] > 0 && Main.myPlayer == projectile.owner)
            {
                for (int i = 0; i < shards; i++)
                {
                    var theta = (float)(Math.PI * Main.rand.NextDouble() * 2);
                    var newVel = new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                    newVel *= 12;
                    Projectile.NewProjectile(projectile.position, newVel, (int)projectile.ai[0], projectile.damage, projectile.knockBack, projectile.owner);
                }
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 50);
        }
    }
}