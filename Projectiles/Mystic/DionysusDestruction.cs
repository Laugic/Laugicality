using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic
{
	public class DionysusDestruction : ModProjectile
    {
        public override void SetDefaults()
        {
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 180;
            projectile.ignoreWater = true;
            projectile.scale = 2f;
        }
		
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 20;
			height = 20;
			return true;
		}

        public override void AI()
        {
            projectile.velocity.Y += .4f;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + .785f;
            //Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Hades"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

        }

		public override void Kill(int timeLeft)
		{
			if (Main.myPlayer == projectile.owner)
			{
               Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("DionysusExplosion"), (int)projectile.damage, 3f, Main.myPlayer);
			}
		}
    }
}