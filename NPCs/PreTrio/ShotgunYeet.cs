using System;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    public class ShotgunYeet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("a yeeted shotgun");
        }

        public override void SetDefaults()
        {
            Main.projFrames[projectile.type] = 4;
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 70;
            projectile.height = 70;
            projectile.alpha = 0;
            projectile.timeLeft = 240;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            
        }

        public override void AI()
        {
            projectile.velocity.Y += .2f;

            projectile.frameCounter++;
            if (projectile.frameCounter > 2)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 3)
            {
                projectile.frame = 0;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, projectile.Center, 51);
            if (!Main.expertMode)
                return;
            for (int k = 0; k < 2; k++)
            {
                var theta = Main.rand.NextDouble() * Math.PI;
                float mag = -5 - Main.rand.NextFloat() * 3;
                Projectile.NewProjectile(projectile.Center, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag), ModContent.ProjectileType<Snowball>(), projectile.damage, 7);
            }
        }
    }
}