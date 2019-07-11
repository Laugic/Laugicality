using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;
using Laugicality.Dusts;
using Terraria.ID;

namespace Laugicality.Projectiles
{
    public class CrystalliteOrb : ModProjectile
    {
        int delay = 0;
        int direction = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystallite");
        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 160;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.light = .5f;
            delay = 20;
        }

        public override void AI()
        {
            if (delay <= 0)
            {
                projectile.scale *= .98f;
                if (projectile.scale <= .05f)
                    projectile.Kill();
            }
            else
            {
                delay--;
            }
            if(direction == 0)
            {
                if (Main.rand.Next(2) == 0)
                    direction = -1;
                else
                    direction = 1;
            }
            projectile.rotation += (float)(Math.PI / 30) * direction;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 5 * 60);
        }
    }
}
