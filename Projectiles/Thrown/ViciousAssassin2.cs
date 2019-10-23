using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Thrown
{
	public class ViciousAssassin2 : ModProjectile
	{
        public bool spawned = false;
        private float _vMag = 16f;
        private float _vAccel = .4f;
        private float _vMax = 22f;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vicious Assassin");
		}

		public override void SetDefaults()
		{
            _vMag = 16f;
            spawned = false;
			projectile.width = 48;
			projectile.height = 48;
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
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType("White"), 0, 0);
            Vector2 targetPos = Main.MouseWorld;
            float dist = Vector2.Distance(targetPos, projectile.Center);
            float tVel = dist / 15;
            if (_vMag < _vMax && _vMag < tVel)
            {
                _vMag += _vAccel;
            }

            if (_vMag > tVel)
            {
                _vMag = tVel;
            }

            if (dist != 0)
            {
                projectile.velocity = projectile.DirectionTo(targetPos) * _vMag;
            }
        }

        public override void Kill(int timeLeft)
        {
            int damage = projectile.damage;
            if (Main.myPlayer == projectile.owner)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 7, 0, ModContent.ProjectileType("ViciousAssassinShard"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -7, 0, ModContent.ProjectileType("ViciousAssassinShard"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 7, ModContent.ProjectileType("ViciousAssassinShard"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -7, ModContent.ProjectileType("ViciousAssassinShard"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, 5, ModContent.ProjectileType("ViciousAssassinShard"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, -5, ModContent.ProjectileType("ViciousAssassinShard"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, -5, ModContent.ProjectileType("ViciousAssassinShard"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, 5, ModContent.ProjectileType("ViciousAssassinShard"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
            }
        }
    }
}