using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Projectiles.Magic
{
    public class BlitzBolt1 : ModProjectile
    {
        public int timer = 0;
        bool justSpawned = false;
        public override void SetDefaults()
        {
            justSpawned = false;
            projectile.width = 14;
            projectile.height = 14;
            projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.timeLeft = 120;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 10;
        }

        public override void AI()
        {
            if (!justSpawned)
            {
                justSpawned = true;
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    Vector2 newPos = projectile.Center;
                    newPos -= projectile.velocity * ((float)i * 0.25f);
                    int dust = Dust.NewDust(newPos, 1, 1, 156, 0f, 0f, 150, default(Color), 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = newPos;
                    Dust dust3 = Main.dust[dust];
                    dust3.velocity *= 0.2f;
                }
            }

            timer++;
            if (timer > 4 || ((LaugicalityWorld.downedEtheria || LaugicalityPlayer.Get(Main.player[projectile.owner]).Etherable > 0) && LaugicalityWorld.downedTrueEtheria && timer > 2))
            {
                if (Main.myPlayer == projectile.owner)
                {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * Main.rand.NextFloat(0.15f, 1.6f), projectile.velocity.Y * Main.rand.NextFloat(0.15f, 1.5f), ModContent.ProjectileType<BlitzBolt2>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                }
                timer = 0;
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 15; k++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 156, 0.85f * -projectile.velocity.X, 0.85f * -projectile.velocity.Y, 100, default(Color), 1.75f);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}