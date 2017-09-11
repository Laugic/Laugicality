using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class TrainScythe : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 76;
			projectile.height = 102;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 8;
			projectile.timeLeft = 120;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 2;

        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            if (projectile.velocity.X < 0) projectile.frame = 1;
            else projectile.frame = 0;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Steam"), 0f, 0f);
		}

        /*
        public override void FindFrame(int frameHeight)
        {
            if (projectile.rotation < 180) projectile.frame = frameHeight;
            else projectile.frame = 0;
        }*/
        /*
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
            projectile.velocity = oldVelocity;
			return false;
		}*/

        public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Steam"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
			Main.PlaySound(SoundID.Item10, projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Electrified"), 120);		//Add Onfire buff to the NPC for 1 second
		}
	}
}