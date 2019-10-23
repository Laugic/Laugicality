using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Magic
{
    public class BookSandstormBottom : ModProjectile
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
            projectile.timeLeft = 300;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 6;
            projectile.penetrate = -1;
        }

        public override void AI()
        {
            Movement();
            FrameAnimation();
            SpawnSandnadoLayers();
        }

        private void Movement()
        {
            if(projectile.velocity.X < 0)
            {
                if (projectile.velocity.X > -4)
                    projectile.velocity.X *= 1.1f;
            }
            else
            {
                if (projectile.velocity.X < 4)
                    projectile.velocity.X *= 1.1f;
            }
            projectile.velocity.Y *= .9f;
        }

        private void MovementAnimation()
        {
            projectile.scale = (projectile.ai[1] / 4f + .5f) / 2;
            theta += (float)Math.PI / 60;
            projectile.position.Y = Main.projectile[(int)projectile.ai[0]].position.Y - projectile.height * (projectile.ai[1] - 1) + 1;
            projectile.position.X = Main.projectile[(int)projectile.ai[0]].position.X + (float)Math.Cos(theta) * 12 * (projectile.ai[1] - 1);
            if (!Main.projectile[(int)projectile.ai[0]].active)
                projectile.Kill();
        }

        private void FrameAnimation()
        {
            projectile.frameCounter++;
            projectile.scale = .5f;
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
            if (num < 5)
            {
                delay++;
                if (delay > 5)
                {
                    delay = 0;
                    Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y - projectile.height * projectile.scale), new Vector2(0, 0), ModContent.ProjectileType<BookSandstormUp>(), projectile.damage, 0, projectile.owner, projectile.whoAmI, num + 1);
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