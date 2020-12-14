using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
    public class JanusConjurationBottom : PrimaryConjurationProjectile
    {
        int delay = 0;
        float theta = 0;
        int num = 1;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandnado");
        }

        public override void SetDefaults()
        {
            num = 1;
            delay = 0;
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 160;
            projectile.height = 21;
            projectile.timeLeft = 12 * 60;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 6;
            projectile.penetrate = -1;
        }

        public override void AI()
        {
            FrameAnimation();
            SpawnSandnadoLayers();
        }

        private void FrameAnimation()
        {
            projectile.frameCounter++;
            projectile.scale = .8f;
            if (projectile.frameCounter > 2)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 5)
            {
                projectile.frame = 0;
            }
        }

        private void SpawnSandnadoLayers()
        {
            if (num < 8)
            {
                delay++;
                if (delay > 5)
                {
                    delay = 0;
                    Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y - projectile.height * projectile.scale), new Vector2(0, 0), ModContent.ProjectileType<JanusConjurationUp>(), projectile.damage, 0, projectile.owner, projectile.whoAmI, num + 1);
                    num++;
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if(target.noGravity == false)
                target.velocity.Y = -12f;
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}