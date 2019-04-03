using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etheria
{
	public class EtherialWave : ModProjectile
    {
        public bool bitherial = true;
        public float dAccel = 0f;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Etherial Wave");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
        {
            dAccel = 0f;
            LaugicalityVars.EProjectiles.Add(projectile.type);
            bitherial = true;
            projectile.width = 22;
			projectile.height = 22;
			//projectile.alpha = 255;
            projectile.timeLeft = 200;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            if (Main.rand.Next(0, 14) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Etherial"), 0f, 0f);
            dAccel += 0.5f;
            projectile.direction += (int)dAccel;
            bitherial = true;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2;
        }

        public override Color? GetAlpha(Color drawColor)
        {
            var b = 125;
            var b2 = 225;
            var b3 = 255;
            if (drawColor.R != (byte)b)
            {
                drawColor.R = (byte)b;
            }
            if (drawColor.G < (byte)b2)
            {
                drawColor.G = (byte)b2;
            }
            if (drawColor.B < (byte)b3)
            {
                drawColor.B = (byte)b3;
            }
            return drawColor;
        }
        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            player.AddBuff(BuffID.Chilled, 90, true);
        }
    }
}