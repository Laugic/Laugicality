using System;
using Microsoft.Xna.Framework;
using Terraria;

namespace Laugicality.Projectiles.Mystic.Burst
{
    public class ObsidiumMysticBurst : MysticProjectile
    {
        public int delay = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thermal Crystalline");
        }

        public override void SetDefaults()
        {
            delay = 0;
            projectile.width = 16;
            projectile.height = 16;
            projectile.timeLeft = 180;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = 2;
        }

        public override void AI()
        {
            if (Main.myPlayer == projectile.owner && projectile.timeLeft < 170)
            {
                Vector2 vec;
                vec.X = Main.MouseWorld.X;
                vec.Y = Main.MouseWorld.Y;

                float num488 = 7.5f;

                Vector2 vector38 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num489 = vec.X - vector38.X;
                float num490 = vec.Y - vector38.Y;
                float num491 = (float)Math.Sqrt((double)(num489 * num489 + num490 * num490));
                num491 = num488 / num491;
                num489 *= num491;
                num490 *= num491;

                projectile.velocity.X = (projectile.velocity.X * 20f + num489) / 21f;
                projectile.velocity.Y = (projectile.velocity.Y * 20f + num490) / 21f;
            }
        }
    }
}