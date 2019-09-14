using Microsoft.Xna.Framework;
using Terraria;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
    public class ChlorysConjuration1 : ConjurationProjectile
    {
        int delay = 0;
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.timeLeft = 360;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            projectile.rotation += projectile.velocity.X / 60;
            projectile.velocity.Y += .5f;
            delay++;
            if (delay > 45)
            {
                delay = 0;
                if (Main.myPlayer == projectile.owner)
                {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -8, mod.ProjectileType<ChlorysConjuration2>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.velocity.Y = 0;
            return false;
        }
    }
}