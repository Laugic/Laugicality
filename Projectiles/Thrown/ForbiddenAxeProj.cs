using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Thrown
{
    public class ForbiddenAxeProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.aiStyle = 0;
            projectile.thrown = true;
            projectile.penetrate = 3;
            projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            projectile.velocity.X *= .99f;
            projectile.velocity.Y += .2f;
            if (projectile.velocity.X < 0)
                projectile.spriteDirection = -1;
            projectile.rotation += projectile.velocity.X / 32;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
            return false;
        }

        public override void Kill(int timeLeft)
        {
            int numProjectiles = Main.rand.Next(3, 7);
            for (int i = 0; i < numProjectiles; i++)
            {
                float theta = Main.rand.NextFloat() * 2 * (float)Math.PI;
                Projectile.NewProjectile(projectile.position, new Vector2((float)Math.Cos(theta) * 14f, (float)Math.Sin(theta) * 14f), ProjectileID.CrystalBullet, projectile.damage, 3, projectile.owner);
            }
            base.Kill(timeLeft);
        }
    }
}