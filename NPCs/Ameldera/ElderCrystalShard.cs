using System;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Ameldera
{
    public class ElderCrystalShard : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elder Crystal Shard");
        }

        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 12;
            projectile.height = 24;
            projectile.timeLeft = 180;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            projectile.velocity.Y += .2f;
        }

    }
}