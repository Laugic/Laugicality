using Terraria;

namespace Laugicality.Projectiles.Mystic.Destruction
{
	public class FreyaDestruction : DestructionProjectile
    {
        public int dir = 0;

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Freya Destruction");
		}

		public override void SetDefaults()
		{
            dir = 0;
			projectile.width = 12;
			projectile.height = 12;
            projectile.timeLeft = 450;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 2;
        }

        public override void AI()
        {
            if(dir == 0)
            {
                if (projectile.velocity.X < 0)
                    dir = -1;
                else
                    dir = 1;
            }
            if (Main.rand.Next(4) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Shroom"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            if (projectile.velocity.Y < 2)
                projectile.velocity.Y += .1f;
            if(dir == 1)
            {
                if(Main.rand.Next(145) == 0)
                    dir = -1;
                if (projectile.velocity.X < 2)
                    projectile.velocity.X += .1f;
            }
            if (dir == -1)
            {
                if (Main.rand.Next(145) == 0)
                    dir = 1;
                if (projectile.velocity.X > -2)
                    projectile.velocity.X -= .1f;
            }
        }
    }
}