using System;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
    public class SaturnConjuration1 : ConjurationProjectile
    {
        float theta = 0;
        float mag = 0;
        int delay = 0;
        Vector2 targetPos;
        float vMax = 16;
        float vMag = 0;
        float vAccel = .8f;

        public override void SetDefaults()
        {
            vMag = 0;
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 18 * 60;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.scale *= .8f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void AI()
        {
            theta += 3.1415f / 120;
            theta += 3.1415f / 120 * (mag / 320);
            AdjustMagnitude();
            targetPos.X = Main.player[projectile.owner].Center.X + (float)(Math.Cos(theta) * mag);
            targetPos.Y = Main.player[projectile.owner].Center.Y + (float)(Math.Sin(theta) * mag);
            Retarget();
            CheckBoom();
            CheckShoot();
            projectile.rotation += .02f;
        }

        private void AdjustMagnitude()
        {
            if (mag < 80)
                mag += 2;
            if (mag < 160)
                mag += 1;
            if (mag < 240)
                mag += .5f;
            if (mag < 480)
                mag += .25f;
            else
                mag += .125f;
        }

        private void Retarget()
        {
            projectile.position = targetPos;
        }

        private void CheckBoom()
        {
            delay++;
            if (delay > 8 * 60)
            {
                if (delay < 16 * 60)
                {
                    if (Main.rand.Next(16 * 60 - delay) == 0 && Main.rand.Next(2) == 0)
                        Boom();
                }
                else
                {
                    Boom();
                }
            }
        }

        private void Boom()
        {
            if (Main.myPlayer == projectile.owner)
            {
                for (int k = 0; k < 8; k++)
                {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next((int)-10f, (int)10f), Main.rand.Next((int)-10f, (int)10f), ModContent.ProjectileType<SaturnConjuration2>(), projectile.damage, 3f, Main.myPlayer);
                }
                projectile.Kill();
            }
        }

        private void CheckShoot()
        {
            if (Main.rand.Next(16 * 60 - delay) == 0 || Main.rand.Next(18 * 60 - delay) == 0)
            {
                Vector2 direction = projectile.DirectionTo(Main.player[projectile.owner].Center);
                if (Main.myPlayer == projectile.owner)
                {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (int)(direction.X * mag / 16), (int)(direction.Y * mag / 16), ModContent.ProjectileType<SaturnConjuration2>(), projectile.damage, 3f, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (int)(direction.X * -mag / 16), (int)(direction.Y * -mag / 16), ModContent.ProjectileType<SaturnConjuration2>(), projectile.damage, 3f, Main.myPlayer);
                }
            }
        }
    }
}
