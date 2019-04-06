using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.RockTwins
{
    public class DioEnergyHoming : ModProjectile
    {
        public bool bitherial = true;
        public bool stopped = false;
        public int power = 0;
        public bool spawned = false;

        public override void SetDefaults()
        {
            LaugicalityVars.EProjectiles.Add(projectile.type);
            power = 0;
            stopped = false;
            spawned = false;
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 22;
            projectile.height = 22;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.timeLeft = 320;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.scale = 1.25f;
        }


        public override void AI()
        {
            bitherial = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Red"), 0f, 0f);
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
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
                projectile.velocity = (16 * projectile.velocity + move) / 5f;
                AdjustMagnitude(ref projectile.velocity);
            }

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
            player.AddBuff(mod.BuffType("ForGlory"), 300, true);
        }

    }
}