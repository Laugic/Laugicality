using System;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    public class Ragnarock : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ragnarock");
        }

        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 16;
            projectile.height = 16;
            projectile.alpha = 0;
            projectile.timeLeft = 240;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.ai[0] = 0;
            projectile.scale = 1f + 2 * Main.rand.NextFloat();
        }

        public override void AI()
        {
            if (Main.rand.Next(4) == 0)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Magma>(), projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f);
            if (projectile.ai[0] == 0)
            {
                projectile.ai[1] = 1 - 2 * Main.rand.Next(2);
                projectile.ai[0] = 1;
            }
            projectile.rotation += 0.02f * projectile.ai[1];
        }
    }
}