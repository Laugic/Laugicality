using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
	public class SharkNeedle : ModProjectile
	{
        public int grounded = 0;
        public bool bitherial = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shark Needle");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
        {
            LaugicalityVars.EProjectiles.Add(projectile.type);
            bitherial = true;
            grounded = 0;
            projectile.width = 32;
			projectile.height = 32;
			//projectile.alpha = 255;
            projectile.timeLeft = 300;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

		public override void AI()
        {
            bitherial = true;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + .785f;

        }
        
    }
}