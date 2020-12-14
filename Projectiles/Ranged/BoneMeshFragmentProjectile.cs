using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Ranged
{
    public class BoneMeshFragmentProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Mesh Fragment");
        }

        public override void SetDefaults()
        {
            LaugicalityVars.SnowballProjectiles.Add(projectile.type);
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 8;
            projectile.height = 8;
            projectile.timeLeft = 60;
            projectile.penetrate = 2;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + .785f;
        }


        public override void Kill(int timeLeft)
        {
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
        }
    }
}
