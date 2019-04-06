using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic.Destruction
{
	public class HadesExplosion : DestructionProjectile
    {
        int projMaxTimeLeft = 0;
        public override void SetDefaults()
        {
            projMaxTimeLeft = 0;
            projectile.width = 64;
            projectile.height = 64;
            projectile.friendly = true;
            projectile.penetrate = 999;
            projectile.timeLeft = 32;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 8;
            projectile.scale *= 2f;
        }

        public override void AI()
        {
            if (projMaxTimeLeft == 0)
                projMaxTimeLeft = projectile.timeLeft;
            projectile.velocity.X = 0;
            projectile.velocity.Y = 0;

            projectile.frameCounter++;
            if (projectile.frameCounter > projMaxTimeLeft / Main.projFrames[projectile.type])
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 8)
            {
                projectile.frame = 8;
            }
        }
    }
}