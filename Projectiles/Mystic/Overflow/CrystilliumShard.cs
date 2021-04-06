using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Overflow
{
    public class CrystilliumShard : MysticProjectile
    {
        public Color colorType;

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 2 * 60;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + .785f;
            projectile.velocity *= 1.1f;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 16, Main.rand.Next((int)-2f, (int)2f), Main.rand.Next((int)-2f, (int)2f), 0, new Color(0, 217, 255), 0.75f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].noLight = true;
            }
        }
    }
}