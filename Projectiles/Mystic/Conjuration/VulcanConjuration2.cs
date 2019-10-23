using Terraria;
using System;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class VulcanConjuration2 : ConjurationProjectile
    {
        private int delay = 0;
        private int delMax = 0;

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vulcan Conjuration");
		}

		public override void SetDefaults()
		{
            delay = 0;
            delMax = 0;
			projectile.width = 22;
			projectile.height = 22;
            projectile.timeLeft = 180;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
        }
        
        public override void AI()
        {
            float mag = 12f;
            float theta = (float)Main.rand.Next(8, 15) / 7;
            bool stopped = false;
            projectile.velocity.X *= .9f;
            projectile.velocity.Y *= .9f;
            if (Math.Abs(projectile.velocity.X) <= .2 && Math.Abs(projectile.velocity.Y) <= .2)
            {
                stopped = true;
            }
            if (delMax == 0)
                delMax = Main.rand.Next(60);
            if(stopped)
                delay++;
            if(delay >= delMax)
            {
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 64);
                float vX = mag * (float)Math.Cos(theta);
                float vY = -mag * (float)Math.Sin(theta);
                if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ModContent.ProjectileType("VulcanConjuration3"), (int)(projectile.damage), 3, Main.myPlayer);
                projectile.Kill();
            }
        }
    }
}