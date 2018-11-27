using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;

namespace Laugicality.Projectiles.Mystic
{
	public class FreyaIllusion : ModProjectile
    {
        public bool stopped = false;
        public int power = 0;
        public int damage = 0;
        public int delay = 0;
        public float mystDur = 1;
		
		public bool shift = false;
		
        public override void SetDefaults()
        {
            mystDur = 1;
            power = 0;
            stopped = false;
            damage = projectile.damage;
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 48;
            projectile.height = 48;
            projectile.friendly = true;
            projectile.penetrate = 8;
            projectile.timeLeft = 300;
            projectile.ignoreWater = true;
            Main.projFrames[projectile.type] = 2;
        }

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int debuff = mod.BuffType("Spored");
            if (debuff >= 0)
            {
                target.AddBuff(debuff, (int)(140 * mystDur * power), true);
            }
        }
		
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 24;
			height = 24;
			return true;
		}

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            power = modPlayer.illusionPower;
            mystDur = modPlayer.mysticDuration;
            projectile.velocity.X *= .95f;
            projectile.velocity.Y *= .95f;
            if(Math.Abs(projectile.velocity.X) <= .2 && Math.Abs(projectile.velocity.Y) <= .2)
            {
                stopped = true;
            }
            
			if (Main.rand.Next(2) == 0)
			{
				int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 56, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 0, default(Color), 1.5f);
				Main.dust[DustID].noGravity = true;
			}

			projectile.rotation += 0.05f;
			if (projectile.timeLeft > 20)
			{
				if (!shift)
				{
					projectile.alpha += 2;
					projectile.scale += 0.0075f;
				}
				else
				{
					projectile.alpha -= 2;
					projectile.scale -= 0.0075f;
				}
				if (projectile.alpha > 175 && !shift)
				{
					shift = true;
				}
				if (projectile.alpha <= 25)
				{
					shift = false;
				}
			}
			else
			{
				projectile.alpha += 5;
			}
        }
		
		public override void PostAI()
        {         
            projectile.frameCounter++;
            if (projectile.frameCounter > 15)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 2)
            {
                projectile.frame = 0;
                return;
            }
        }
    }
}