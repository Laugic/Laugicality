using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Ranged
{
    public class ClusterballProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clusterball");
        }

        public override void SetDefaults()
        {
            LaugicalityVars.SnowballProjectiles.Add(projectile.type);
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 16;
            projectile.height = 16;
            projectile.timeLeft = 300;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            projectile.velocity.Y += .9f;
            projectile.velocity.X *= .975f;
        }

        public override void Kill(int timeLeft)
        {
            int shards = Main.rand.Next(2, 5);
            if (Main.myPlayer == projectile.owner)
            {
                for (int i = 0; i < shards; i++)
                {
                    var theta = (float)(Math.PI * Main.rand.NextDouble() * 2);
                    var newVel = new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                    newVel *= 10;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, newVel.X, newVel.Y, ModContent.ProjectileType<ClusterballFragmentProjectile>(), projectile.damage / 2, 3, Main.myPlayer);
                }
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 50);
        }
    }
}
