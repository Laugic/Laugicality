using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Melee
{
    public class EnginatorMProj : ModProjectile
    {
        public int rot = 0;
        public int delay = 0;
        public bool reverse = false;

        public override void SetDefaults()
        {
            reverse = false;
            delay = 20;
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = -1;
            projectile.aiStyle = 0;
            projectile.timeLeft = 400;
            Main.projFrames[projectile.type] = 2;
        }
        
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            if (projectile.velocity.X < 0) projectile.frame = 1;
            else projectile.frame = 0;

            delay -= 1;
            if(delay <= 0 && reverse == false)
            {
                projectile.velocity.X *= .95f;
                projectile.velocity.Y *= .95f;
                if (Math.Abs(projectile.velocity.X) < 4f && Math.Abs(projectile.velocity.Y) < 4f)
                {
                    projectile.velocity.X = -projectile.velocity.X;
                    projectile.velocity.Y = -projectile.velocity.Y;
                    reverse = true;
                }
            }
            if (reverse)
            {
                if (projectile.localAI[0] == 0f)
                {
                    AdjustMagnitude(ref projectile.velocity);
                    projectile.localAI[0] = 1f;
                }
                Vector2 move = Vector2.Zero;
                float distance = 1400f;
                bool target = false;
                
                    Vector2 newMove = Main.player[Main.myPlayer].Center - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                    
                
                if (target)
                {
                    AdjustMagnitude(ref move);
                    projectile.velocity = (20 * projectile.velocity + move) / 5f;
                    AdjustMagnitude(ref projectile.velocity);
                }

                Vector2 delta = Main.player[Main.myPlayer].Center - projectile.Center;
                if (Math.Abs(delta.X) < 8 && Math.Abs(delta.Y) < 8)
                    projectile.Kill();
            }
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 10f)
            {
                vector *= 10f / magnitude;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            reverse = true;
            projectile.ai[0] += 0.1f;
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y;
            }
            projectile.tileCollide = false;
            return false;
        }
        
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("Steamy"), 120);       //Add Onfire buff to the NPC for 1 second
        }
    }
}