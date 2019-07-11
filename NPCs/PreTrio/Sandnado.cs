using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
	public class Sandnado : ModProjectile
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
            if(projectile.ai[1] == 1)
                Movement();
            else
                MovementAnimation();
            FrameAnimation();
            SpawnSandnadoLayers();
        }

        private void Movement()
        {
            if (projectile.Center.X < Main.player[projectile.owner].Center.X - 4)
                projectile.velocity.X = 2;
            else if (projectile.Center.X > Main.player[projectile.owner].Center.X + 4)
                projectile.velocity.X = -2;
            else
                projectile.velocity.X = 0;
            if(projectile.Center.Y < Main.player[projectile.owner].Center.Y + 12)
                projectile.velocity.Y = 2;
            else if (projectile.Center.Y > Main.player[projectile.owner].Center.Y - 20)
                projectile.velocity.Y = -1;
            else
                projectile.velocity.Y = 0;
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

        private void SpawnSandnadoLayers()
        {
            if (delay >= 0)
                delay++;
            if (delay > 15 && projectile.ai[1] < 5)
            {
                delay = -2;
                if (projectile.ai[1] != 1 && Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y - projectile.height * projectile.scale), new Vector2(0, 0), mod.ProjectileType<Sandnado>(), projectile.damage, 0, projectile.owner, projectile.ai[0], projectile.ai[1] + 1);
                else if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y - projectile.height * projectile.scale), new Vector2(0, 0), mod.ProjectileType<Sandnado>(), projectile.damage, 0, projectile.owner, projectile.whoAmI, projectile.ai[1] + 1);
            }
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            target.velocity.Y = -26f;
        }
    }
}