using Terraria;
using Laugicality.Dusts;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
	public class VulcanIllusion : IllusionProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 100;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            buffID = ModContent.BuffType("Steamy");
        }

        public override void AI()
        {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Steam>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }
        
    }
}