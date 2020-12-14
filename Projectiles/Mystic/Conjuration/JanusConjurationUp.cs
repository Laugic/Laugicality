using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
    public class JanusConjurationUp : ConjurationProjectile
    {
        int delay = 0;
        float theta = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandnado");
        }

        public override void SetDefaults()
        {
            delay = 0;
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 80;
            projectile.height = 32;
            projectile.timeLeft = 30000;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 6;
            projectile.penetrate = -1;
        }

        public override void AI()
        {
            Shoot();
            MovementAnimation();
            FrameAnimation();
        }

        private void Shoot()
        {
            if(Main.rand.Next(3 * 60) == 0 && Main.myPlayer == projectile.owner)
            {
                var theta = (float)(Math.PI * -Main.rand.NextDouble());
                Vector2 newVel = new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                Vector2 pos = new Vector2(projectile.Center.X - (projectile.width / 2) * projectile.scale + Main.rand.Next((int)((projectile.width) * projectile.scale)), projectile.Center.Y);
                newVel *= 16;
                int id = Projectile.NewProjectile(pos.X, pos.Y, newVel.X, newVel.Y, ModContent.ProjectileType<JanusConjurationSandball>(), projectile.damage, 3, Main.myPlayer);
            }
        }

        private void MovementAnimation()
        {
            projectile.scale = (projectile.ai[1] / 6f + .5f);
            projectile.width = (int)(156 * projectile.scale);
            theta += (float)Math.PI / 60;
            projectile.position.Y = Main.projectile[(int)projectile.ai[0]].position.Y - projectile.height * (projectile.ai[1] - 1);
            projectile.position.X = Main.projectile[(int)projectile.ai[0]].position.X + (float)Math.Cos(theta) * 12 * (projectile.ai[1] - 1);
            if (!Main.projectile[(int)projectile.ai[0]].active)
                projectile.Kill();
        }

        private void FrameAnimation()
        {
            projectile.frameCounter++;
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

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.noGravity == false)
                target.velocity.Y = -12f;
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}