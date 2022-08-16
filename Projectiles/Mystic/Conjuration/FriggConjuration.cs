using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class FriggConjuration : ConjurationProjectile
    {
        public bool stopped = false;
        public int power = 0;
        public int damage = 0;
        public int delay = 0;

        public override void SetDefaults()
        {
            power = 0;
            stopped = false;
            damage = projectile.damage;
            projectile.width = 32;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 5 * 60;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 4;
        }

        public override void AI()
        {
            projectile.rotation = 0;
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            projectile.velocity.X *= .95f;
            projectile.velocity.Y *= .975f;
			
			if (projectile.velocity.X > 0f)
			{
				projectile.spriteDirection = -1;
			}
			else
			{
				projectile.spriteDirection = 1;
			}
			
            if(Math.Abs(projectile.velocity.X) <= .2 && Math.Abs(projectile.velocity.Y) <= .2)
            {
                stopped = true;
            }
            if (stopped)
            {
                delay += 1;
                if(delay >= 20)
                {
                    delay = 0;
                    if (Main.myPlayer == projectile.owner)
                    {
                        if (player.strongBees && Main.rand.Next(3) == 0)
                            Projectile.NewProjectile(projectile.Center.X - 4 + Main.rand.Next(9), projectile.Center.Y - 4 + Main.rand.Next(9), 0, 0.1f, ProjectileID.GiantBee, (int)(projectile.damage * 1.5f), 2f, projectile.owner);
                        else
                            Projectile.NewProjectile(projectile.Center.X - 4 + Main.rand.Next(9), projectile.Center.Y - 4 + Main.rand.Next(9), 0, 0.1f, ProjectileID.Bee, (int)(projectile.damage), 2f, projectile.owner);

                        for (int k = 0; k < 5; k++)
						{
							int num234 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 20) - projectile.velocity, projectile.width, projectile.height, 153, Main.rand.NextFloat(-1f, 1f), 3f, 50, default(Color), 1f);
							Dust dust3 = Main.dust[num234];
							dust3 = Main.dust[num234];
							dust3.velocity *= 0.95f;
							Main.dust[num234].noGravity = true;
						}
					}
                }
            }
			
			if (projectile.timeLeft < 20)
			{
				projectile.alpha += 10;
			}
        }
		
		public override void PostAI()
        {         
            projectile.frameCounter++;
            if (projectile.frameCounter > 3)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 4)
            {
                projectile.frame = 0;
                return;
            }
        }
        
    }
}