using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
	public class HatSpin : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hat");
		}

		public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 40;
			projectile.height = 20;
            projectile.timeLeft = 10 * 60;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 6;
        }

		public override void AI()
        {
            DespawnCheck();
            Movement();
            FrameAnimation();
        }

        private void DespawnCheck()
        {
            if (!(Main.npc[(int)projectile.ai[1]].type == ModContent.NPCType<Hypothema>()) || !Main.npc[(int)projectile.ai[1]].active || Main.npc[(int)projectile.ai[1]].ai[0] == 1)
                projectile.Kill();
        }

        private void Movement()
        {
            projectile.ai[0]++;
            if(projectile.ai[0] < 6 * 60)
            {
                MoveTowardsAtSpeed(Main.player[projectile.owner].Center, 6);
                projectile.velocity.Y *= .9f;
            }
            else
            {
                if (Main.npc[(int)projectile.ai[1]].type == ModContent.NPCType<Hypothema>() && Main.npc[(int)projectile.ai[1]].active)
                {
                    MoveTowardsAtSpeed(Main.npc[(int)projectile.ai[1]].Center, 6);
                    if (Vector2.Distance(projectile.Center, Main.npc[(int)projectile.ai[1]].Center) < 20)
                        projectile.Kill();
                }
            }
        }

        private void MoveTowardsAtSpeed(Vector2 targetPos, float mag)
        {
            Vector2 newVel = Vector2.Normalize(targetPos - projectile.Center);
            newVel *= Math.Min(Vector2.Distance(projectile.Center, targetPos) / 4, Math.Min(mag, projectile.velocity.Length() + .6f));
            projectile.velocity = newVel;
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
    }
}