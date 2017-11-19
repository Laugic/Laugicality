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
	public class VulcanConjuration : ModProjectile
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
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }


        public override void AI()
        {
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
                if(delay >= 30)
                {
                    delay = 0;
                    power++;

                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 7, 0, mod.ProjectileType("ElectrosparkP2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -7, 0, mod.ProjectileType("ElectrosparkP2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 7, mod.ProjectileType("ElectrosparkP2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -7, mod.ProjectileType("ElectrosparkP2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, 5, mod.ProjectileType("ElectrosparkP2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, -5, mod.ProjectileType("ElectrosparkP2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, -5, mod.ProjectileType("ElectrosparkP2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, 5, mod.ProjectileType("ElectrosparkP2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    if (power >= modPlayer.conjurationPower)
                        projectile.Kill();
                }
            }
               
        }
        
    }
}