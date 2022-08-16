using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Projectiles.Magic
{
    public class BlitzBolt2 : ModProjectile
    {
        public int timer = 0;
        public float reduce = 0f;
        bool justSpawned = false;
        public override void SetDefaults()
        {
            justSpawned = false;
            projectile.width = 10;
            projectile.height = 10;
            projectile.alpha = 255;
            projectile.penetrate = 1;
            projectile.timeLeft = 60;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 10;
            projectile.magic = true;
        }

        public override void AI()
        {
            for (int i = 0; i < 1; i++)
            {
                Vector2 newPos = projectile.Center;
                newPos -= projectile.velocity * ((float)i * 0.25f);
                projectile.alpha = 50;
                int dust = Dust.NewDust(newPos, 1, 1, 156, 0f, 0f, 150, default(Color), 1.25f - reduce);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].position = newPos;
                Dust dust3 = Main.dust[dust];
                dust3.velocity *= 0.2f;
            }

            if (reduce < 2f)
            {
                reduce += 0.025f;
            }

            timer++;
            if (timer > 2)
            {
                projectile.velocity.Y += Main.rand.NextFloat(-1.5f, 1.5f);
                projectile.velocity.X += Main.rand.NextFloat(-1.5f, 1.5f);
                timer = 0;
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, 0.5f * -projectile.velocity.X, 0.5f * -projectile.velocity.Y, 100, default(Color), 0.5f);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}