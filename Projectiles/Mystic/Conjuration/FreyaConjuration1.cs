using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class FreyaConjuration1 : PrimaryConjurationProjectile
    {
        public bool stopped = false;
        public int damage = 0;
        public int sporeTimer = 0;

        public override void SetDefaults()
        {
            stopped = false;
            damage = projectile.damage;
            projectile.width = 44;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 60 * 5;
            Main.projFrames[projectile.type] = 2;
            projectile.ignoreWater = true;
            LaugicalityVars.ShroomProjectiles.Add(projectile.type);
        }

		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			Rectangle frame = new Rectangle(0, 0, 48, 38);
			frame.Y += 38 * projectile.frame;	
			
			spriteBatch.Draw(mod.GetTexture("Projectiles/Mystic/Conjuration/FreyaConjuration1_Glow"), projectile.Center - Main.screenPosition, frame, Color.White * 0.25f, projectile.rotation, new Vector2(22, 17), 1f, SpriteEffects.None, 0f);
		}

        public override bool PreAI()
        {
            projectile.tileCollide = true;
            return true;
        }
		
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
			
			Lighting.AddLight(projectile.position, 0.1f, 0.1f, 0.4f);
			
            projectile.velocity.X *= 0.9f;
			projectile.velocity.Y += 0.5f;
			projectile.rotation = 0;

            if (stopped)
            {
                sporeTimer++;
                if (sporeTimer >= 15)
                {
                    if (Main.myPlayer == projectile.owner)
                    {
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -10f, ModContent.ProjectileType<FreyaConjuration2>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
					}
					sporeTimer = 0;
                }
            }
        }
		
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 10; k++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 56, Main.rand.Next((int)-5f, (int)5f), Main.rand.Next((int)-5f, (int)5f), 50, default(Color), 1f);
				Main.dust[dust].noGravity = true;
			}
			for (int k = 0; k < 8; k++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 4, Main.rand.Next((int)-3f, (int)3f), Main.rand.Next((int)-3f, (int)3f), 100, default(Color), 1f);
				Main.dust[dust].noGravity = true;
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
			if (stopped)
            {
				projectile.frameCounter++;
				if (projectile.frameCounter > 5)
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
}