using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class DionysusConjuration : ConjurationProjectile
    {
        public bool stopped = false;
        public int delay = 0;

        public override void SetDefaults()
        {
            stopped = false;
            projectile.width = 54;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 8 * 60;
            Main.projFrames[projectile.type] = 6;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            projectile.rotation = 0;
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            projectile.velocity *= .9f;
            if(Math.Abs(projectile.velocity.X) <= .2 && Math.Abs(projectile.velocity.Y) <= .2)
            {
                stopped = true;
            }
            if (stopped)
            {
                delay += 1;
                if(delay >= 10)
                {
                    delay = 0;
                    if (Main.myPlayer == projectile.owner)
                    {
                        Projectile.NewProjectile(projectile.Center.X + Main.rand.Next(-16, 16), projectile.Center.Y - 6 + Main.rand.Next(16), 0, 10, ModContent.ProjectileType<DionysusConjuration2>(), (int)(projectile.damage), 3f, Main.myPlayer);
                    }
                }
            }
        }
		
		public override void PostAI()
        {         
            projectile.frameCounter++;
            if (projectile.frameCounter > 5)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 6)
            {
                projectile.frame = 0;
                return;
            }
        }
    }
}