using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class VulcanConjuration : ConjurationProjectile
    {
        public bool stopped = false;

        public override void SetDefaults()
        {
            stopped = false;
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.aiStyle = 1;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            projectile.velocity.Y += .2f;
        }

        public override void Kill(int TimeLeft)
        {
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
            if (Main.myPlayer == projectile.owner)
            {
                for(int i = 0; i < 7; i++)
                {
                    float theta = (float)(Main.rand.Next(45)) / 7;
                    int mag = Main.rand.Next(6, 17);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(theta)*mag, (float)Math.Sin(theta) * mag, ModContent.ProjectileType<VulcanConjuration2>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                }
            }
        }
        
    }
}