using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class ObsidiumArrowHead : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magma Shard");     
		}

		public override void SetDefaults()
		{
			projectile.width = 18;               
			projectile.height = 36;              
			projectile.aiStyle = 1;             
			projectile.friendly = true;         
			projectile.hostile = false;         
			projectile.ranged = true;           
			projectile.penetrate = -1;           
			projectile.timeLeft = 600;            
			projectile.ignoreWater = true;         
			projectile.tileCollide = true;          
			//aiType = 1;           
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			return false;
		}
        

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
                target.AddBuff(BuffID.OnFire, 120, true);
        }
    }
}
