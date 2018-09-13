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
    public class UltimateLeader6 : ModProjectile
    {
        public bool spawned = false;
        public Vector2 targetPos;
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Obsidium Arrow Head");     
        }

        public override void SetDefaults()
        {
            spawned = false;
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.penetrate = 5;           
            projectile.timeLeft = 120;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            if (!spawned)
            {
                spawned = true;
                float distance = 10000f;
                foreach (NPC npc in Main.npc)
                {
                    if (Vector2.Distance(projectile.Center, npc.Center) < distance && !npc.friendly && npc.damage > 0 && !npc.dontTakeDamage)
                    {
                        targetPos = npc.Center;
                        distance = Vector2.Distance(projectile.Center, npc.Center);
                    }
                }
                if (distance == 10000f)
                    targetPos = Main.MouseWorld;
                projectile.velocity = projectile.DirectionTo(targetPos) * 18f;
            }

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2;

        }

    }
}