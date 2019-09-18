using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Laugicality.Projectiles.Mystic.Illusion
{
	public class HallowsEveIllusion2 : IllusionProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 14;
			projectile.alpha = 200;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 90;
			aiType = ProjectileID.SpikyBall;
            buffID = mod.BuffType("Spooked");
        }

        public override void AI()
		{
			if (Main.rand.Next(2) == 0)
			{
				int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 1f, 125, default(Color), 1.25f);
				Main.dust[DustID].noGravity = true;
			}
			
			if (projectile.timeLeft < 20)
			{
				projectile.alpha += 10;
			}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}