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
        public override void SetDefaults()
        {
            mystDur = 1;
            power = 0;
            stopped = false;
            damage = projectile.damage;
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 32;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.penetrate = 8;
            projectile.timeLeft = 300;
            Main.projFrames[projectile.type] = 2;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
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
            
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Shroom"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

            projectile.frameCounter++;
            if (projectile.frameCounter > 30)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 1)
            {
                projectile.frame = 0;
            }
            if (projectile.frame == 0)
                projectile.scale *= .98f;
            if (projectile.frame == 1)
                projectile.scale *= 1.02f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int debuff = mod.BuffType("Spored");
            if (debuff >= 0)
            {
                target.AddBuff(debuff, (int)(140 * mystDur * power), true);
            }
        }
    }
}