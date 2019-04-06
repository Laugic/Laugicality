using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class Electrospark : ModProjectile
	{
        private int _delay = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electrospark");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 48;
			//projectile.alpha = 255;
            projectile.timeLeft = 240;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = 1;
            _delay = 0;
        }

        public override void AI()
        {
            _delay += 1;
            if(_delay == 25 && Main.myPlayer == projectile.owner)
            {
                //Main.PlaySound(SoundID.Item33, (int)projectile.position.X, (int)projectile.position.Y);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X + 3, projectile.velocity.Y + 3, mod.ProjectileType("ElectrosparkP2"), projectile.damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X + 3, projectile.velocity.Y - 3, mod.ProjectileType("ElectrosparkP2"), projectile.damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X - 3, projectile.velocity.Y - 3, mod.ProjectileType("ElectrosparkP2"), projectile.damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X - 3, projectile.velocity.Y + 3, mod.ProjectileType("ElectrosparkP2"), projectile.damage, 3f, Main.myPlayer);
            }
        }
    }
}