using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Mounts
{
	public class Etherblast : ModProjectile
	{
        private int delay = 0;
        public int damage = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Etherblast");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 48;
			//projectile.alpha = 255;
            projectile.timeLeft = 180;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = 3;
            delay = 0;
            damage = 50;
        }

        public override void AI()
        {
            projectile.rotation += .4f;
            delay += 1;
            if(delay > 60 && Main.myPlayer == projectile.owner)
            {
                delay = 0;
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 8, 0, mod.ProjectileType("EtherblastP2"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -8, 0, mod.ProjectileType("EtherblastP2"), damage, 3f, Main.myPlayer);
            }
        }
        
    }
}