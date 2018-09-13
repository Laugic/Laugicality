using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class BloodBall : ModProjectile
	{

        public static Vector2 posS;
        public static Vector2 playS;
        public static Vector2 playN;
        public static bool spawned = false;
        public float mag = 1.5f;
        public int delay = 0;

		public override void SetDefaults()
		{
            delay = 0;
            spawned = false;
			projectile.width = 10;
			projectile.height = 10;
			//projectile.alpha = 255;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 300;
		}

		public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (!spawned)
            {
                spawned = true;
                //Vector2 position = Main.screenPosition;
                //position.X += Main.mouseX;
                //position.Y += player.gravDir == 1 ? Main.mouseY : Main.screenHeight - Main.mouseY;
                posS = player.position;
                playS = player.position;
            }
            playN = player.position;
            projectile.position.X = posS.X + (playN.X - playS.X) * mag;
            projectile.position.Y = posS.Y + (playN.Y - playS.Y) * mag;
            if(delay == 0 && Main.netMode != 1)
            {
                delay = 4;
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("BloodBall2"), projectile.damage, 3f, Main.myPlayer);
            }
            delay--;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Rainbow"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }

        public override void Kill(int timeLeft)
        {
            BloodBall2.kill = true;
        }
        
    }
}