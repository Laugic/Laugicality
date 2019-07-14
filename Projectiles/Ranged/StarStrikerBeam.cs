using Terraria.ModLoader;
using System;

namespace Laugicality.Projectiles.Ranged
{
	public class StarStrikerBeam : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 12;               
			projectile.height = 6;              
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
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
        }
    }
}
