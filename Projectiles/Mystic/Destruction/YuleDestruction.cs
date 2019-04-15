using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Laugicality.Projectiles.Mystic.Destruction
{
	public class YuleDestruction : DestructionProjectile
    {
        public bool spawned = false;
        private float vMag = 16f;
        private float vAccel = .4f;
        private float vMax = 22f;
        bool homing = true;

		public override void SetDefaults()
		{
            homing = true;
            vMag = 16f;
            spawned = false;
			projectile.width = 48;
			projectile.height = 48;
            projectile.timeLeft = 120;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f * 3;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Frost"), 0, 0);
            Vector2 targetPos = Main.MouseWorld;
            float dist = Vector2.Distance(targetPos, projectile.Center);
            float tVel = dist / 15;
            if (vMag < vMax && vMag < tVel && homing)
            {
                vMag += vAccel;
            }
            if (dist != 0 && homing)
            {
                projectile.velocity = projectile.DirectionTo(targetPos) * vMag;
            }
            if (dist < vMag + 2f && homing)
                homing = false;
        }
    }
}