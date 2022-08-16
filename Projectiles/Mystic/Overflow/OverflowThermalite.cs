using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Overflow
{
    public class OverflowThermalite : MysticProjectile
    {
        public Color colorType;
        bool shot = false;
        Vector2 shotDir;
        public override void SetDefaults()
        {
            shot = false;
            shotDir = Vector2.Zero;
            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 3 * 60;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }
        public override void AI()
        {
            if(shotDir == Vector2.Zero)
            {
                shotDir = projectile.position + projectile.velocity * 60;
                double theta = Main.rand.NextFloat() * Math.PI * 2;
                float mag = 8;
                projectile.velocity = new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag);
            }


            if(shot)
            {
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            }
            else
            {
                projectile.rotation += projectile.velocity.Length() * (projectile.velocity.X > 0?1:-1) / 10f;
                projectile.velocity *= .92f;
                if (projectile.velocity.Length() < .1f)
                {
                    shot = true;
                    var newVel = shotDir - projectile.position;
                    newVel.Normalize();
                    newVel *= 12;
                    projectile.velocity = newVel;
                }
            }
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