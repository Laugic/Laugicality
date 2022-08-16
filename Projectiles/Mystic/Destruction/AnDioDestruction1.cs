using System;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Destruction
{
    public class AnDioDestruction1 : DestructionProjectile
    {
        public bool stopped = false;
        public int delay = 0;
        public bool spawned = false;
        public float theta = 0;
        public float vel = 0;
        public bool zImmune = true;
        public float tVel = 0;
        public float distance = 0;
        public Vector2 origin;
        public Vector2 originV;
        public double mag = 10;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Loki Spiral");
        }
        public override void SetDefaults()
        {
            mag = 10;
            zImmune = true;
            theta = 0;
            vel = 0;
            stopped = false;
            spawned = false;
            projectile.width = 24;
            projectile.height = 24;
            projectile.penetrate = 3;
            projectile.friendly = true;
            projectile.timeLeft = 320;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

		public override Color? GetAlpha(Color lightColor)
		{
			return ((Color.White * 0.85f) * (0.1f * projectile.timeLeft));
		}

        public override void AI()
        {
            delay -= 1;
            if (delay <= 0)
            {
                delay = 4;
                Vector2 move = Vector2.Zero;
                bool target = false;
                float distance = 1400f;
                for (int i = 0; i < 200; i++)
                {
                    NPC npcT = Main.npc[i];
                    if (!npcT.friendly)
                    {
                        Vector2 newMove = npcT.Center - projectile.Center;
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
                    projectile.velocity = (20 * projectile.velocity + move) / 11f;
                    AdjustMagnitude(ref projectile.velocity);
                }

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
    }
}