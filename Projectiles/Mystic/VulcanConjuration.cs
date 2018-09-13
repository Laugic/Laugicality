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
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.aiStyle = 1;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }


        public override void AI()
        {
            projectile.velocity.Y += .2f;
            
        }
        public override void Kill(int TimeLeft)
        {
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            int damage = projectile.damage;
            if (Main.myPlayer == projectile.owner)
            {
                for(int i = 0; i < modPlayer.conjurationPower*2 + 2; i++)
                {
                    float theta = (float)(Main.rand.Next(45)) / 7;
                    int mag = Main.rand.Next(6, 17);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(theta)*mag, (float)Math.Sin(theta) * mag, mod.ProjectileType("VulcanConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                }
            }
        }
        
    }
}