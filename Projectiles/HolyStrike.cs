using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class HolyStrike : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Obsidium Arrow Head");     
		}

		public override void SetDefaults()
		{
			projectile.width = 64;               
			projectile.height = 64;              
			projectile.aiStyle = -1;             
			projectile.friendly = true;         
			projectile.hostile = false;         
			projectile.melee = true;           
			projectile.penetrate = -1;           
			projectile.timeLeft = 60;            
			projectile.ignoreWater = true;         
			projectile.tileCollide = false;
            projectile.scale = 3f;      
		}

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 255, 255, 255);
        }
    }
}
