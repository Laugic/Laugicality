using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class ViciousAssassinMain : ModProjectile
	{
        public bool spawned = false;
        private float vMag = 16f;
        private float vAccel = .4f;
        private float vMax = 22f;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vicious Assassin");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
		{
            vMag = 16f;
            spawned = false;
			projectile.width = 48;
			projectile.height = 48;
			//projectile.alpha = 255;
            projectile.timeLeft = 180;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = 2;
        }

        public override void AI()
        {
            projectile.rotation += 1.57f / 20;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("White"), 0, 0);
            Vector2 targetPos = Main.MouseWorld;
            float dist = Vector2.Distance(targetPos, projectile.Center);
            float tVel = dist / 15;
            if (vMag < vMax && vMag < tVel)
            {
                vMag += vAccel;
            }

            if (vMag > tVel)
            {
                vMag = tVel;
            }

            if (dist != 0)
            {
                projectile.velocity = projectile.DirectionTo(targetPos) * vMag;
            }
        }

        public override void Kill(int timeLeft)
        {
            int damage = projectile.damage;
            if (Main.myPlayer == projectile.owner)
            {

                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 7, 0, mod.ProjectileType("ViciousAssassinShard"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -7, 0, mod.ProjectileType("ViciousAssassinShard"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 7, mod.ProjectileType("ViciousAssassinShard"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -7, mod.ProjectileType("ViciousAssassinShard"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, 5, mod.ProjectileType("ViciousAssassinShard"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, -5, mod.ProjectileType("ViciousAssassinShard"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, -5, mod.ProjectileType("ViciousAssassinShard"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, 5, mod.ProjectileType("ViciousAssassinShard"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);

            }
        }
    }
}