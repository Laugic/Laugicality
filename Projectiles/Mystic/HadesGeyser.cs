using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic
{
	public class HadesGeyser : ModProjectile
    {
        public bool powered = false;
        public int power = 1;
        public double rot = 0.0;
        public int damage = 0;
        public int delay = 0;
        public int delayMax = 4;
        public int dir = 0;

        public override void SetDefaults()
        {
            power = 1;
            powered = false;
            delayMax = 4;
            damage = projectile.damage;
            rot = 0.0;
            delay = 0;
            dir = 0;
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 125;
            projectile.ignoreWater = true;
            projectile.alpha = 250;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);


            damage = (int)(projectile.damage/2);
            if (dir == 0)dir = -1 + 2*Main.rand.Next(0, 2);
            rot += dir*0.02;
            if(Main.rand.Next(3) == 0)
                rot += dir * 0.04;
            if (Main.rand.Next(3) == 0)
                rot += dir * 0.04;
            projectile.rotation = (float)rot;
            delay++;
            if (delay >= delayMax)
            {
                delay = 0;
                if (Main.myPlayer == projectile.owner)
                {
                    float mag = 8f;
                    for(int i = 0; i < modPlayer.conjurationPower + 3; i++)
                    {
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)(Math.Cos(rot + (float)(Math.PI * 2 * i / (modPlayer.conjurationPower + 3)))) * mag, (float)(Math.Sin(rot + (float)(Math.PI * 2 * i / (modPlayer.conjurationPower + 3)))) * mag, mod.ProjectileType("HadesGeyserBurst"), damage, 3f, Main.myPlayer);
                    }
                }
            }
        }
    }
}