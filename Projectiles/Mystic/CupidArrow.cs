using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic
{
	public class CupidArrow : ModProjectile
    {
        public int damage = 0;
        public bool powered = false;
        public int power = 1;
        public float mystDur = 0f;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heartburn Arrow");     
		}

		public override void SetDefaults()
        {
            power = 1;
            powered = false;
            projectile.width = 18;               
			projectile.height = 18;              
			projectile.aiStyle = 1;             
			projectile.friendly = true;         
			projectile.hostile = false;         
			projectile.ranged = true;           
			projectile.penetrate = 2;           
			projectile.timeLeft = 600;            
			projectile.ignoreWater = true;         
			projectile.tileCollide = false;          
			//aiType = 1;           
		}
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (!powered)
            {
                powered = true;
                Vector2 targetPos;
                targetPos.X = Main.MouseWorld.X;
                targetPos.Y = Main.MouseWorld.Y;
                projectile.velocity = projectile.DirectionTo(targetPos) * 12f;
            }
            power = modPlayer.illusionPower;
            mystDur = modPlayer.mysticDuration;
            
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			return false;
		}
        

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
                target.AddBuff(mod.BuffType("Lovestruck"), (int)(140 * mystDur * power));
        }
    }
}
