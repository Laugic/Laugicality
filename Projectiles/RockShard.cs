using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;


namespace Laugicality.Projectiles
{
	public class RockShard : ModProjectile
    {

        public override void SetDefaults()
        {
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = 4;
            projectile.timeLeft = 60;
            projectile.ignoreWater = true;
        }

        

        public override void AI()
        {
            projectile.rotation += .02f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y;
            }
            return false;
        }
        
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, (int)(120));
        }
    }
}