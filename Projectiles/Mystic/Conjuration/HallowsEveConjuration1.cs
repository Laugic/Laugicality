using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class HallowsEveConjuration1 : ConjurationProjectile
    {
        public bool stopped = false;
        public int timer = 0;
		public int offset = 0;
        bool justSpawned = false;
        int delay = 0;

        public override void SetDefaults()
        {
            delay = 0;
            stopped = false;
            justSpawned = false;
            projectile.width = 44;
            projectile.height = 32;
            projectile.penetrate = -1;
            projectile.timeLeft = 7 * 60;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            Main.projFrames[projectile.type] = 2;
        }
		
		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			Rectangle frame = new Rectangle(0, 0, 44, 36);
			frame.Y += 36 * projectile.frame;	
			if (projectile.spriteDirection == 1)
			{
				spriteBatch.Draw(mod.GetTexture("Projectiles/Mystic/Conjuration/HallowsEveConjuration1_Glow"), projectile.Center - Main.screenPosition, frame, Color.White * 0.5f, projectile.rotation, new Vector2(22, 18), 1f, SpriteEffects.None, 0f);
			}
			else
			{
				spriteBatch.Draw(mod.GetTexture("Projectiles/Mystic/Conjuration/HallowsEveConjuration1_Glow"), projectile.Center - Main.screenPosition, frame, Color.White * 0.5f, projectile.rotation, new Vector2(22, 18), 1f, SpriteEffects.FlipHorizontally, 0f);
			}
		}
        
        public override bool PreAI()
        {
            projectile.tileCollide = true;
            return true;
        }

        public override void AI()
        {
			Lighting.AddLight(projectile.position, 0.5f, 0.35f, 0.15f);
            projectile.velocity.X *= .95f;
            projectile.velocity.Y += 1f;
            delay++;
			if (delay > 10)
			{
				timer++;
				if (timer >= 20)
				{
					projectile.frameCounter = 0;
					float distance = 2000f;
					int index = -1;
					for (int i = 0; i < 200; i++)
					{
						float dist = Vector2.Distance(projectile.Center, Main.npc[i].Center);
						if (dist < distance && dist < 700f && Main.npc[i].CanBeChasedBy(projectile, false))
						{
							index = i;
							distance = dist;
						}
					}
					if (index != -1)
					{
						if (Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[index].position, Main.npc[index].width, Main.npc[index].height))
						{
							Vector2 vector = Main.npc[index].Center - projectile.Center;
							float speed = 12f;
							float mag = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
							if (mag > speed && mag != 0)
							{
								mag = speed / mag;
							}
							vector *= mag;
							
							if (vector.X > 0f)
							{
								projectile.spriteDirection = -1;
								offset = 16;
							}
							else
							{
								projectile.spriteDirection = 1;
								offset = -16;
							}
				
							int choice = Main.rand.Next(3);
							if (choice == 0)
							{
								Projectile.NewProjectile(projectile.Center.X + offset, projectile.Center.Y, vector.X, vector.Y, ModContent.ProjectileType<HallowsEveConjuration2>(), (int)(projectile.damage * 1f), 3f, projectile.owner);
							}
							else if (choice == 1)
							{
								Projectile.NewProjectile(projectile.Center.X + offset, projectile.Center.Y, vector.X, vector.Y - 5f, ModContent.ProjectileType<HallowsEveConjuration3>(), (int)(projectile.damage * 1.25f), 3f, projectile.owner);
							}
							else
							{
								Projectile.NewProjectile(projectile.Center.X + offset, projectile.Center.Y, vector.X, vector.Y, ModContent.ProjectileType<HallowsEveConjuration4>(), (int)(projectile.damage * 0.75f), 3f, projectile.owner);
							}
						}
					}
					timer = 0;
				}
			}
			else
			{
				if (projectile.velocity.X > 0f)
				{
					projectile.spriteDirection = -1;
				}
				else
				{
					projectile.spriteDirection = 1;
				}
			}

			if (projectile.timeLeft < 20)
			{
				projectile.alpha += 10;
			}
        }
		
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			fallThrough = false; 
			return true;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			stopped = true;
			return false;
		}
		
		public override void PostAI()
        {         
            projectile.frameCounter++;
            if (projectile.frameCounter > 6)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 2)
            {
                projectile.frame = 0;
                return;
            }
        }
    }
}