using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etheria
{
	public class TrueEtherialPulse : ModProjectile
    {
        public bool bitherial = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Etherial Pulse");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
        {
            LaugicalityVars.EProjectiles.Add(projectile.type);
            bitherial = true;
            projectile.width = 22;
			projectile.height = 22;
			//projectile.alpha = 255;
            projectile.timeLeft = 80;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.scale = 2f;
        }

        public override void AI()
        {
            if (Main.rand.Next(0, 14) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Etherial"), 0f, 0f);
            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 1400f;
            bool target = false;
            for (int k = 0; k < 8; k++)
            {
                if (Main.player[k].active)
                {
                    Vector2 newMove = Main.player[k].Center - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target)
            {
                AdjustMagnitude(ref move);
                projectile.velocity = (27 * projectile.velocity + move) / 5f;
                AdjustMagnitude(ref projectile.velocity);
            }
            bitherial = true;
        }


        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }

        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            player.AddBuff(BuffID.Chilled, 90, true);
        }
    }
}