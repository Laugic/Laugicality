using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Laugicality.Projectiles
{
    public class SteamOfSteamworks : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steam of Steamworks");
        }

        public override void SetDefaults()
        {
            projectile.width = 48;
            projectile.height = 48;
            //projectile.alpha = 255;
            projectile.timeLeft = 60;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = 4;
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
            if (Main.rand.Next(8) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Steam"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("Steamy"), 4 * 60, true);
        }
    }
}