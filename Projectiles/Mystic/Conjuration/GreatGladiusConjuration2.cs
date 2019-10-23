using Terraria;
using System;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class GreatGladiusConjuration2 : ConjurationProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            if(Main.rand.Next(4) == 0)Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType("White"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            projectile.velocity.Y += .15f;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2;
        }
    }
}