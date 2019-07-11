using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;
using Laugicality.Dusts;
using Terraria.ID;

namespace Laugicality.Projectiles
{
    public class GoodShadowflame : ModProjectile
    {
        public bool stopped = false;
        int delay = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowflame");
        }

        public override void SetDefaults()
        {
            stopped = false;
            projectile.width = 12;
            projectile.height = 12;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 160;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.light = .5f;
            delay = 20;
        }


        public override void AI()
        {
            if (stopped)
            {
                projectile.velocity.X *= .8f;
                projectile.velocity.Y = 0;
                projectile.scale *= .985f;
                if (projectile.scale <= .05f)
                    projectile.Kill();
            }
            else if (delay <= 0)
            {
                projectile.velocity.Y += projectile.ai[0];
                projectile.ai[0] += .008f;
                projectile.velocity.X *= .99f;
            }
            else
            {
                delay--;
            }

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            stopped = true;
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 5 * 60);
        }
    }
}
