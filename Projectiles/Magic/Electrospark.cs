using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Magic
{
	public class Electrospark : ModProjectile
	{
        private int delay = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electrospark");
		}

		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 48;
            projectile.timeLeft = 240;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = 1;
            delay = 0;
        }

        public override void AI()
        {
            delay += 1;
            if(delay == 25 && Main.myPlayer == projectile.owner)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X + 3, projectile.velocity.Y + 3, mod.ProjectileType("ElectrosparkP2"), projectile.damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X + 3, projectile.velocity.Y - 3, mod.ProjectileType("ElectrosparkP2"), projectile.damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X - 3, projectile.velocity.Y - 3, mod.ProjectileType("ElectrosparkP2"), projectile.damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X - 3, projectile.velocity.Y + 3, mod.ProjectileType("ElectrosparkP2"), projectile.damage, 3f, Main.myPlayer);
            }
        }
    }
}