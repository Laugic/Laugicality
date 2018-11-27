using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;

namespace Laugicality.Projectiles.Mystic
{
	public class HallowsEveIllusion2 : ModProjectile
    {
        public int power = 1;
        public float mystDur = 1f;
        public override void SetDefaults()
        {
            power = 1;
            mystDur = 1f;
            projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 14;
			projectile.alpha = 200;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 90;
			aiType = ProjectileID.SpikyBall;
		}

        public override void OnHitNPC(NPC npc, int damage, float knockback, bool crit)
        {
            npc.AddBuff(mod.BuffType("Spooked"), (int)(160 * mystDur * power));
        }

        public override void AI()
		{
			if (Main.rand.Next(2) == 0)
			{
				int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 1f, 125, default(Color), 1.25f);
				Main.dust[DustID].noGravity = true;
			}
			
			if (projectile.timeLeft < 20)
			{
				projectile.alpha += 10;
			}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}