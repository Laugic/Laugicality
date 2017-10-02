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
        public double rot = 0.0;
        public int damage = 0;
        public int delay = 0;
        public int dir = 0;

        public override void SetDefaults()
        {
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
            damage = projectile.damage/2;
            if (dir == 0)dir = -1 + 2*Main.rand.Next(0, 2);
            rot += dir*0.02;
            if(Main.rand.Next(3) == 0)
                rot += dir * 0.04;
            if (Main.rand.Next(3) == 0)
                rot += dir * 0.04;
            projectile.rotation = (float)rot;
            delay++;
            if (delay >= 4) {
                delay = 0;
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(rot) * 8f, (float)Math.Sin(rot) * 8f, mod.ProjectileType("HadesGeyserBurst"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(rot + 1.57) * 8f, (float)Math.Sin(rot + 1.57) * 8f, mod.ProjectileType("HadesGeyserBurst"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(rot + 3.14) * 8f, (float)Math.Sin(rot + 3.14) * 8f, mod.ProjectileType("HadesGeyserBurst"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(rot + 4.71) * 8f, (float)Math.Sin(rot + 4.71) * 8f, mod.ProjectileType("HadesGeyserBurst"), damage, 3f, Main.myPlayer);
            }
        }
    }
}