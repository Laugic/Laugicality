using System;
using Terraria;
using Microsoft.Xna.Framework;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class HallowsEveConjuration4 : ConjurationProjectile
    {
		public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.penetrate = 1;
			projectile.friendly = true;
            projectile.timeLeft = 180;
        }
		
		public override void AI()
		{
			projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			
			for (int i = 0; i < 3; i++)
            {
                float xSpeed = projectile.velocity.X / 3f * (float)i;
                float ySpeed = projectile.velocity.Y / 3f * (float)i;
                int newDust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 111, 0f, 0f, 125, default(Color), 1.25f);
                Main.dust[newDust].position.X = projectile.Center.X - xSpeed;
                Main.dust[newDust].position.Y = projectile.Center.Y - ySpeed;
                Main.dust[newDust].velocity *= 0.15f;
				Main.dust[newDust].noGravity = true;
            }
			
			Player player = Main.player[projectile.owner];
			float xPos = projectile.Center.X;
			float yPos = projectile.Center.Y;
			float maxDist = 500f;
			bool target = false;
			
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].CanBeChasedBy(projectile, false) && projectile.Distance(Main.npc[i].Center) < maxDist && Collision.CanHit(projectile.Center, 1, 1, Main.npc[i].Center, 1, 1))
				{
					float xDiff = Main.npc[i].position.X + (float)(Main.npc[i].width / 2);
					float yDiff = Main.npc[i].position.Y + (float)(Main.npc[i].height / 2);
					float dist = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - xDiff) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - yDiff);
					if (dist < maxDist)
					{
						maxDist = dist;
						xPos = xDiff;
						yPos = yDiff;
						target = true;
					}
				}
			}
			
			if (target)
			{
				float vel = 6f;
				
				Vector2 position = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float xTarget = xPos - position.X;
				float yTarget = yPos - position.Y;
				float dist = (float)Math.Sqrt((double)(xTarget * xTarget + yTarget * yTarget));
				dist = vel / dist;
				xTarget *= dist;
				yTarget *= dist;
				
				projectile.velocity.X = (projectile.velocity.X * 20f + xTarget) / 21f;
				projectile.velocity.Y = (projectile.velocity.Y * 20f + yTarget) / 21f;
			}
		}
	}
}