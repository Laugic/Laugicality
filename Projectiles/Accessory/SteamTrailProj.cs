using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;
using Laugicality.Dusts;
using Terraria.ID;
using Laugicality.Buffs;

namespace Laugicality.Projectiles.Accessory
{
    public class SteamTrailProj : ModProjectile
    {
        int delay = 0;
        int direction = 0;
        int frame = -1;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steam");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 160;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.light = .5f;
            delay = 20;
            Main.projFrames[projectile.type] = 3;
        }

        public override void AI()
        {
            if (frame == -1)
                frame = Main.rand.Next(3);
            projectile.frame = frame;
            if (delay <= 0)
            {
                projectile.scale *= 1.01f;
                if (projectile.scale > 1.5f)
                    projectile.alpha += 2;
                if (projectile.alpha > 250)
                    projectile.Kill();
            }
            else
            {
                delay--;
            }
            if (direction == 0)
            {
                if (Main.rand.Next(2) == 0)
                    direction = -1;
                else
                    direction = 1;
            }
            projectile.velocity.Y -= .02f;
            projectile.rotation += (float)(Math.PI / 60) * direction;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType<Steamy>(), 5 * 60);
        }
    }
}
