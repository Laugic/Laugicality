using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;
using System;
using System.Collections.Generic;

namespace Laugicality.Projectiles.Mystic
{
	public class GreatGladiusConjuration2 : ModProjectile
    {
        public float mystDmg = 0;
        public float mystDur = 0;

        public override void SetDefaults()
        {
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        

        public override void AI()
        {
            /*Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            mystDur = modPlayer.mysticDuration;*/
            if(Main.rand.Next(4) == 0)Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("White"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            projectile.velocity.Y += .15f;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2;
        }

        
    }
}