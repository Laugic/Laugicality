using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    public class SandnadoUp : ModProjectile
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
            projectile.width = 160;
            projectile.height = 42;
            projectile.timeLeft = 300;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 6;
        }

        public override void AI()
        {
            MovementAnimation();
            FrameAnimation();
        }

        private void MovementAnimation()
        {
            projectile.scale = projectile.ai[1] / 4f + .5f;
            theta += (float)Math.PI / 60;
            projectile.position.Y = Main.projectile[(int)projectile.ai[0]].position.Y - projectile.height * (projectile.ai[1] - 1) + 1;
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

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            target.velocity.Y = -26f;
        }
    }
}