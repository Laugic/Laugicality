using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    public class SnowCloud : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snow Cloud");
        }

        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 192;
            projectile.height = 110;
            projectile.timeLeft = 32 * 60;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 8;
        }

        public override void AI()
        {
            if (!(Main.npc[(int)projectile.ai[1]].type == ModContent.NPCType<Hypothema>()) || !Main.npc[(int)projectile.ai[1]].active)
                projectile.Kill();
            FrameAnimation();
            //if (Main.npc[(int)projectile.ai[1]].type == ModContent.NPCType<Hypothema>() && Main.npc[(int)projectile.ai[1]].active)
            {
            //    if (Main.player[projectile.owner].Center.Y < projectile.Center.Y)
                var newPos = projectile.position;
                newPos.X += Main.rand.Next(projectile.width);
                newPos.Y += projectile.height / 2 + Main.rand.Next(projectile.height / 3);
                if (Main.rand.Next(4) == 0)
                    Projectile.NewProjectile(newPos, new Vector2(0, 2), ModContent.ProjectileType<QuietSnowball>(), projectile.damage, 7, 255, 1);
            }
        }

        private void FrameAnimation()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 4)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 7)
            {
                projectile.frame = 0;
            }
        }


        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 3 * 60 + Main.rand.Next(60), true);
            target.AddBuff(BuffID.Chilled, 3 * 60 + Main.rand.Next(60), true);
        }
    }
}