using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etherial.BossFights
{
    public class EtherialStinger : ModProjectile
    {
        public int grounded = 0;
        public int delay = 4;
        public bool bitherial = true;
        bool powered = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Etherial Stinger");
        }

        public override void SetDefaults()
        {
            powered = false;
            LaugicalityVars.eProjectiles.Add(projectile.type);
            bitherial = true;
            delay = 4;
            grounded = 0;
            projectile.width = 12;
            projectile.height = 12;
            //projectile.alpha = 255;
            projectile.timeLeft = 150;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            bitherial = true;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);

            bitherial = true;
            projectile.rotation -= 6;
            if (!powered)
            {
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 51);
                Vector2 move = Vector2.Zero;
                float distance = 2400f;
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
                    projectile.velocity = (16 * projectile.velocity + move) / 11f;
                    AdjustMagnitude(ref projectile.velocity);
                }
                projectile.velocity *= 24;
                powered = true;
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

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            if (LaugicalityWorld.downedEtheria)
            {
                target.AddBuff(mod.BuffType("Frostbite"), 4 * 60, true);
            }
        }
    }
}