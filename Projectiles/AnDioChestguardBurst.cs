using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;

namespace Laugicality.Projectiles
{
	public class AnDioChestguardBurst : ModProjectile
	{
        public int delay = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AnDio Chestguard Burst");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
		{
            delay = 0;
			projectile.width = 16;
			projectile.height = 16;
			//projectile.alpha = 255;
            projectile.timeLeft = 180;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = 3;
        }

        public override void AI()
        {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("White"), 0f, 0f);
            delay -= 1;
            if (delay <= 0)
            {
                delay = 4;
                Vector2 move = Vector2.Zero;
                bool target = false;
                float distance = 1400f;
                for (int i = 0; i < 200; i++)
                {
                    NPC npcT = Main.npc[i];
                    //If the npc is hostile
                    if (!npcT.friendly)
                    {
                            Vector2 newMove = npcT.Center - projectile.Center;
                            float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                            if (distanceTo < distance)
                            {
                                move = newMove;
                                distance = distanceTo;
                                target = true;
                            
                            }
                    }
                }
                
                if (target)
                {
                    AdjustMagnitude(ref move);
                    projectile.velocity = (20 * projectile.velocity + move) / 11f;
                    AdjustMagnitude(ref projectile.velocity);
                }

            }
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