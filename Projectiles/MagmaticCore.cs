using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
    public class MagmaticCore : ModProjectile
    {
        public float dust = 0f;

        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 38;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.aiStyle = 66;
            projectile.minionSlots = 1f;
            projectile.timeLeft = 18000;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft *= 5;
            projectile.minion = true;
            aiType = 388;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);// + 1.57f;

            if (projectile.velocity.X < 0) projectile.frame = 1;
            else projectile.frame = 0;
            //projectile.frame = 0;

            if (Main.rand.Next(6) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Magma"), 0, Math.Abs(projectile.velocity.Y) * -0.1f);

            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (player.dead)
            {
                modPlayer.mCore = false;
            }
            if (modPlayer.mCore)
            {
                projectile.timeLeft = 2;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate == 0)
            {
                projectile.Kill();
            }
            return false;
        }

    }
}