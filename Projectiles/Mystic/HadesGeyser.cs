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
            if (!powered)
            {
                powered = true;
                while (modPlayer.conjurationPower > power)
                {
                    power++;
                    delayMax -= 1;
                }
            }

            damage = projectile.damage/2;
            if (dir == 0)dir = -1 + 2*Main.rand.Next(0, 2);
            rot += dir*0.02;
            if(Main.rand.Next(3) == 0)
                rot += dir * 0.04;
            if (Main.rand.Next(3) == 0)
                rot += dir * 0.04;
            projectile.rotation = (float)rot;
            delay++;
            if (delay >= delayMax && Main.netMode != 1) {
                delay = 0;
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(rot) * 8f, (float)Math.Sin(rot) * 8f, mod.ProjectileType("HadesGeyserBurst"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(rot + 1.57) * 8f, (float)Math.Sin(rot + 1.57) * 8f, mod.ProjectileType("HadesGeyserBurst"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(rot + 3.14) * 8f, (float)Math.Sin(rot + 3.14) * 8f, mod.ProjectileType("HadesGeyserBurst"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(rot + 4.71) * 8f, (float)Math.Sin(rot + 4.71) * 8f, mod.ProjectileType("HadesGeyserBurst"), damage, 3f, Main.myPlayer);
            }
        }
    }
}