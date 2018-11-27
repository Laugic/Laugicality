using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;

namespace Laugicality.Projectiles.Mystic
{
	public class FriggConjuration : ModProjectile
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
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 32;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 4;
        }

        public override void AI()
        {
            projectile.rotation = 0;
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
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
                if(delay >= 10)
                {
                    delay = 0;
                    power++;

                    if (Main.myPlayer == projectile.owner)
                    {
                        Projectile.NewProjectile(projectile.Center.X - 4 + Main.rand.Next(9), projectile.Center.Y - 4 + Main.rand.Next(9), 0, 0.1f, 181, (int)(projectile.damage * 0.80f), 3f, Main.myPlayer);
						for (int k = 0; k < 5; k++)
						{
							int num234 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 20) - projectile.velocity, projectile.width, projectile.height, 153, Main.rand.NextFloat(-1f, 1f), 3f, 50, default(Color), 1f);
							Dust dust3 = Main.dust[num234];
							dust3 = Main.dust[num234];
							dust3.velocity *= 0.95f;
							Main.dust[num234].noGravity = true;
						}
					}
                    if (power >= modPlayer.conjurationPower * 5 + 3)
                        projectile.Kill();
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