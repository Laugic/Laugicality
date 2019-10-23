using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    public class Fireball : ModProjectile
    {
        public int spawned = 0;
        public int delay = 0;
        public bool bitherial = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("a Fireball");
        }

        public override void SetDefaults()
        {
            Main.projFrames[projectile.type] = 3;
            LaugicalityVars.eProjectiles.Add(projectile.type);
            bitherial = true;
            delay = 0;
            spawned = 0;
            projectile.width = 42;
            projectile.height = 42;
            projectile.alpha = 0;
            projectile.timeLeft = 240;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            
        }

        public override void AI()
        {
            bitherial = true;
            Vector2 newVel = -projectile.velocity / 2f;
            float theta = Main.rand.Next(-30, 30) * (float)Math.PI / 180;
            float mag = (float)Main.rand.NextDouble() * 2;
            newVel.X += (float)Math.Cos(theta) * mag;
            newVel.Y += (float)Math.Sin(theta) * mag;
            Dust.NewDust(projectile.position - projectile.velocity, projectile.width, projectile.height, ModContent.DustType("SuperMagma"), newVel.X, newVel.Y);
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 1.57f;
            if (spawned == 0) { 
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
                projectile.velocity = (16 * projectile.velocity + move) / 11f;
                AdjustMagnitude(ref projectile.velocity);
            }
                projectile.velocity *= 28;
                spawned = 1;
            }

            projectile.frameCounter++;
            if (projectile.frameCounter > 4)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 2)
            {
                projectile.frame = 0;
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
                target.AddBuff(BuffID.OnFire, 4 * 60, true);
        }
    }
}