using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Ranged
{
    public class ClusterballFragmentProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clusterball Fragment");
        }

        public override void SetDefaults()
        {
            LaugicalityVars.SnowballProjectiles.Add(projectile.type);
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 8;
            projectile.height = 8;
            projectile.timeLeft = 60;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            projectile.velocity.Y += .4f;
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y;
            }
            return false;
        }


        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 51);
        }
    }
}
