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
	public class PlutoConjuration : ModProjectile
    {
        public bool stopped = false;
        public int power = 0;
        public int damage = 0;
        public int delay = 0;
        public bool growing = true;

        public override void SetDefaults()
        {
            growing = true;
            power = 0;
            stopped = false;
            damage = projectile.damage;
            projectile.width = 84;
            projectile.height = 84;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }


        public override void AI()
        {
            if (growing)
            {
                if (projectile.scale < 1.5f)
                {
                    projectile.scale += 0.02f;
                }
                else growing = false;
            }
            else
            {
                if (projectile.scale > .75f)
                {
                    projectile.scale -= 0.02f;
                }
                else growing = true;
            }
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            projectile.velocity.X *= .92f;
            projectile.velocity.Y *= .92f;
            if(Math.Abs(projectile.velocity.X) <= .2 && Math.Abs(projectile.velocity.X) <= .2)
            {
                stopped = true;
            }
            if (stopped && Main.netMode != 1)
            {
                delay += 1;
                if(delay >= 45)
                {
                    delay = 0;
                    power++;

                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("PlutoConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                   
                    if (power >= modPlayer.conjurationPower * 2)
                        projectile.Kill();
                }
            }
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Frost"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

        }
        
    }
}