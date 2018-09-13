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
	public class FreyaConjuration1 : ModProjectile
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
            projectile.width = 64;
            projectile.height = 64;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            Main.projFrames[projectile.type] = 2;
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
                if(delay >= 15)
                {
                    delay = 0;
                    power++;

                    if (Main.myPlayer == projectile.owner)
                    {
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -10, mod.ProjectileType("FreyaConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    }
                    if (power >= modPlayer.conjurationPower * 6 + 4)
                        projectile.Kill();
                }
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
                projectile.scale = 1f;
            if (projectile.frame == 1)
                projectile.scale = 1.1f;
        }
        
    }
}