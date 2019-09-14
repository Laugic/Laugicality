using Terraria;

namespace Laugicality.Projectiles.Mystic.Destruction
{
	public class ShroomBoom : DestructionProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 64;
            projectile.height = 64;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 24;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 6;
        }

        public override void AI()
        {
            projectile.velocity.X = 0;
            projectile.velocity.Y = 0;

            projectile.frameCounter++;
            if (projectile.frameCounter > 4)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 6)
            {
                projectile.frame = 6;
            }
        }
    }
}