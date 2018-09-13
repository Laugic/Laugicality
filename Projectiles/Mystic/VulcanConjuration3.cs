using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;
using System;

namespace Laugicality.Projectiles.Mystic
{
	public class VulcanConjuration3 : ModProjectile
    {

        private bool spawned = false;
        public override void SetDefaults()
        {
            spawned = false;
            projectile.width = 32;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 120;
            projectile.aiStyle = 0;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 3;
        }

        
        
        public override void AI()
        {
            if (!spawned)
            {
                spawned = true;
                projectile.frame = Main.rand.Next(3);
                Vector2 targetPos;
                targetPos.X = Main.MouseWorld.X;
                targetPos.Y = Main.MouseWorld.Y;
                projectile.velocity = projectile.DirectionTo(targetPos) * 12f;
            }

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
        }
        
        
    }
}