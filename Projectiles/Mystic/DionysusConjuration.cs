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
	public class DionysusConjuration : ModProjectile
    {
        public bool stopped = false;
        public int power = 0;
        public int damage = 0;
        public int delay = 0;

        public override void SetDefaults()
        {
            power = 0;
            stopped = false;
            damage = projectile.damage;
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 54;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 900;
            Main.projFrames[projectile.type] = 6;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }


        public override void AI()
        {
            projectile.rotation = 0;
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            projectile.velocity.X *= .95f;
            projectile.velocity.Y *= .95f;
            if(Math.Abs(projectile.velocity.X) <= .2 && Math.Abs(projectile.velocity.Y) <= .2)
            {
                stopped = true;
            }
            if (stopped)
            {
                delay += 1;
                if(delay >= 10)
                {
                    delay = 0;
                    power++;

                    if (Main.myPlayer == projectile.owner)
                    {
                        Projectile.NewProjectile(projectile.Center.X - projectile.width / 2 + Main.rand.Next(projectile.width), projectile.Center.Y - 8 + Main.rand.Next(16), 0, 10, mod.ProjectileType("DionysusConjuration2"), (int)(projectile.damage), 3, Main.myPlayer);
                    }
                }
            }
                //Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Shroom"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

            projectile.frameCounter++;
            if (projectile.frameCounter > 30)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 5)
            {
                projectile.frame = 0;
            }
            if (projectile.frame == 0)
                projectile.scale = 1f;
            if (projectile.frame == 1)
                projectile.scale = 1.1f;
        }
        
    }
}