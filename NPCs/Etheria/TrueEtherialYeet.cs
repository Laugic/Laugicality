using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etheria
{
	public class TrueEtherialYeet : ModProjectile
    {
        public bool bitherial = true;
        public bool stopped = false;
        public int power = 0;
        public int damage = 0;
        public int delay = 0;
        public bool spawned = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Etherial Pulse");
        }
        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            power = 0;
            stopped = false;
            damage = 20;
            spawned = false;
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 16;
            projectile.height = 16;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.timeLeft = 180;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }


        public override void AI()
        {
            bitherial = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Etherial"), 0f, 0f);
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
                projectile.velocity = (10 * projectile.velocity + move) / 11f;
                AdjustMagnitude(ref projectile.velocity);
            }

            projectile.velocity *= 4;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2;
        }


        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }

        public override Color? GetAlpha(Color drawColor)
        {
            var b = 225;
            var b2 = 125;
            var b3 = 155;
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
            player.AddBuff(44, 300, true);//Frostburn
        }

    }
}