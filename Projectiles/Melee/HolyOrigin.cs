using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Melee
{
	public class HolyOrigin : ModProjectile
	{
        public int delay = 0;
		public override void SetDefaults()
		{
            delay = 0;
			projectile.width = 6;
			projectile.height = 6;
			projectile.aiStyle = 0;
			projectile.scale = 1f;
			projectile.penetrate = 1;
			projectile.timeLeft = 120;
			projectile.tileCollide = false;
            projectile.friendly = false;
            projectile.scale = 2;
		}
		
		public override void AI()
		{
            delay--;
            if(delay <= 0)
            {
                delay = 4;
                if(Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 48, mod.ProjectileType("HolyStrike"), (int)(projectile.damage), 3, Main.myPlayer);
            }
        }
	}
}