using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;

namespace Laugicality.Projectiles.Thrown
{
	public class ViciousAssassinShard : ModProjectile
    {
        public int delay = 0;

		public override void SetDefaults()
        {
            delay = 0;
            projectile.width = 16;               
			projectile.height = 16;              
			projectile.aiStyle = -1;             
			projectile.friendly = true;         
			projectile.hostile = false;         
			projectile.ranged = true;           
			projectile.penetrate = -1;           
			projectile.timeLeft = 240;            
			projectile.ignoreWater = true;         
			projectile.tileCollide = false;          
		}

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if(Main.rand.Next(4) == 0)Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("White"), 0, 0);
            Vector2 move = Vector2.Zero;
            float distance = 1400f;
            Vector2 newMove = Main.MouseWorld - projectile.Center;
            float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
            move = newMove;
            distance = distanceTo;
            AdjustMagnitude(ref move);
            projectile.velocity = (20 * projectile.velocity + move) / 11f;
            AdjustMagnitude(ref projectile.velocity);
            
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }
    }
}
