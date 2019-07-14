using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;

namespace Laugicality.Projectiles.Ranged
{
	public class Luminarrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Luminarrow");     
		}
        public bool stopped = false;
		public override void SetDefaults()
		{
            stopped = false;
			projectile.width = 18;               
			projectile.height = 36;              
			projectile.aiStyle = -1;             
			projectile.friendly = true;         
			projectile.hostile = false;         
			projectile.ranged = true;           
			projectile.penetrate = -1;           
			projectile.timeLeft = 240;            
			projectile.ignoreWater = true;         
			projectile.tileCollide = false;          
			//aiType = 1;           
		}


        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("White"), projectile.velocity.X * 0f, projectile.velocity.Y * 0f);
            if (!stopped)
            {
                projectile.velocity.X *= .92f;
                projectile.velocity.Y *= .92f;
            }

            if (Math.Abs(projectile.velocity.X) <= .2 && Math.Abs(projectile.velocity.Y) <= .2)
            {
                if (!stopped)
                {
                    stopped = true;
                    Vector2 targetPos;
                    targetPos.X = Main.MouseWorld.X;
                    targetPos.Y = Main.MouseWorld.Y;
                    projectile.velocity = projectile.DirectionTo(targetPos) * 22f;
                }
            }
        }
    }
}
