using Terraria;
using Terraria.ModLoader;
using System;
using Laugicality.Buffs;
using Laugicality.Dusts;

namespace Laugicality.Projectiles.Magic
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
            if (Main.rand.Next(8) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Steam>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Steamy>(), 4 * 60, true);
        }
    }
}