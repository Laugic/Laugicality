using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.SoulStone
{
    public class ElectroAura : ModProjectile
    {
        float theta = 0;
        float range = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electroaura");
        }

        public override void SetDefaults()
        {
            projectile.width = 48;
            projectile.height = 48;
            projectile.timeLeft = 120;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
        }

        public override void AI()
        {
            theta -= (float)Math.PI / 60;
            if (projectile.timeLeft <= 30)
                range -= 3;
            else if (range < 90)
                range += 3;
            projectile.position.X = (float)(Math.Cos(theta) * range) + Main.player[projectile.owner].position.X;
            projectile.position.Y = (float)(Math.Sin(theta) * range) + Main.player[projectile.owner].position.Y;
        }
    }
}