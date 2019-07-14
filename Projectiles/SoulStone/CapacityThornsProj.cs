using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;


namespace Laugicality.Projectiles.SoulStone
{
    public class CapacityThornsProj : ModProjectile
    {
        float theta = 0;
        bool spawned = false;
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 800;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
        }

        public override void AI()
        {
            if (!spawned)
            {
                spawned = true;
                theta = projectile.ai[0];
            }
            Player player = Main.player[projectile.owner];
            
            theta += (float)(Math.PI / 60);
            float mag = 48;
            projectile.position.X = player.position.X + (float)Math.Cos(theta) * mag;
            projectile.position.Y = player.position.Y + (float)Math.Sin(theta) * mag;
            projectile.rotation = theta + (float)Math.PI / 2;
        }
    }
}