using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Ranged
{
    public class BoneMeshProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            LaugicalityVars.SnowballProjectiles.Add(projectile.type);
            projectile.width = 14;
            projectile.height = 14;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.timeLeft = 600;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            projectile.velocity.Y += .5f;
            projectile.velocity.X *= .975f;
        }

        public override void Kill(int timeLeft)
        {
            int shards = Main.rand.Next(4);
            if (Main.myPlayer == projectile.owner)
            {
                for (int i = 0; i < shards; i++)
                {
                    var theta = (float)(Math.PI * Main.rand.NextDouble() * 2);
                    var newVel = new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                    newVel *= 10;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, newVel.X, newVel.Y, ModContent.ProjectileType<BoneMeshFragmentProjectile>(), projectile.damage / 2, 3, Main.myPlayer);
                }
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
        }
    }
}