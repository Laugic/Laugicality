using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Necrodon
{
    public class Eighth : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("An Eighth Note");
        }

        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 32;
            projectile.height = 32;
            projectile.timeLeft = 10 * 60;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.ai[0] = 0;
        }

        public override void AI()
        {
            float light = 0.8f;
            Lighting.AddLight(projectile.Center + projectile.velocity, light, light, light);

            projectile.rotation = 0;// (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
            if (projectile.rotation > Math.PI / 2 && projectile.rotation < Math.PI * 1.5)
            {
                projectile.rotation += (float)Math.PI;
            }
            else
                projectile.spriteDirection = 1;
            if (projectile.timeLeft < 30)
            {
                projectile.alpha += 4;
                projectile.scale *= .98f;
            }
        }
    }
}
