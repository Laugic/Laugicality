using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;

namespace Laugicality.NPCs.TheGreatShadow
{
	public class ShadowBurst : ModProjectile
    {
        public bool bitherial = true;
        public int delay = 60;
        public bool zImmune = true;
        public float mag = 0;
        public Vector2 dustPos;
        public override void SetDefaults()
        {
            zImmune = true;
            delay = 60;
            LaugicalityVars.EProjectiles.Add(projectile.type);
            projectile.width = 16;
            projectile.height = 16;
            projectile.hostile = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 240;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }
        

        public override void AI()
        {
            bitherial = true;
            delay -= 1;
            if (delay <= 0)
                projectile.Kill();
            mag += 3f;
            int k = 12;
            Random random = new Random();
            float theta = 6.28f * (float)random.NextDouble();
            while(k > 0)
            { 
                k--;
                theta = 6.28f * (float)random.NextDouble();
                dustPos.X = projectile.Center.X + mag*(float)Math.Cos(theta);
                dustPos.Y = projectile.Center.Y + mag*(float)Math.Sin(theta);
                Dust.NewDustPerfect(dustPos, mod.DustType("Black"), null);
            }
        }

    }
}