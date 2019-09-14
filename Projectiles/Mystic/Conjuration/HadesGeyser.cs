using System;
using Terraria;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class HadesGeyser : ConjurationProjectile
    {
        public double rot = 0.0;
        public int delay = 0;
        public int delayMax = 4;
        public int dir = 0;

        public override void SetDefaults()
        {
            delayMax = 4;
            rot = 0.0;
            delay = 0;
            dir = 0;
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 3 * 60;
            projectile.ignoreWater = true;
            projectile.alpha = 250;
        }

        public override void AI()
        {
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
                    for(int i = 0; i < 4; i++)
                    {
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)(Math.Cos(rot + (float)(Math.PI * 2 * i / 4))) * mag, (float)(Math.Sin(rot + (float)(Math.PI * 2 * i / 4))) * mag, mod.ProjectileType("HadesGeyserBurst"), (int)(projectile.damage / 2), 3f, Main.myPlayer);
                    }
                }
            }
        }
    }
}