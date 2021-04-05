using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    public class Steward : ModProjectile
    {
        static float maxXVel = 12f;
        static float maxXAcc = .2f;
        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 80;
            projectile.height = 80;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.timeLeft = 14 * 60;
        }

        public override void AI()
        {
            projectile.netUpdate = true;

            if (projectile.scale != 1)
                return;
            Movement();


            if (Main.rand.Next(4) == 0)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<SnowCloudDust>(), projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);
            if (!Main.npc[(int)projectile.ai[0]].active || Main.npc[(int)projectile.ai[0]].type != ModContent.NPCType<Hypothema>() || Main.npc[(int)projectile.ai[0]].life < 1)
                projectile.active = false;

            projectile.rotation += projectile.velocity.X / 40f;
        }

        private void Movement()
        {
            if (projectile.Center.Y < Main.player[Main.npc[(int)projectile.ai[0]].target].Center.Y && projectile.ai[1] < .1f)
                projectile.ai[1] += .02f;
            if (projectile.velocity.Y < 12)
                projectile.velocity.Y += projectile.ai[1] + .02f;
            if (projectile.Center.X < Main.player[Main.npc[(int)projectile.ai[0]].target].Center.X && projectile.velocity.X < maxXVel)
                projectile.velocity.X += maxXAcc;
            if (projectile.Center.X > Main.player[Main.npc[(int)projectile.ai[0]].target].Center.X && projectile.velocity.X > -maxXVel)
                projectile.velocity.X -= maxXAcc;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(2, projectile.Center, 51);
            if (projectile.velocity.X != oldVelocity.X)
                projectile.velocity.X = -oldVelocity.X;
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.ai[1] = 0;
                projectile.velocity.Y = -oldVelocity.Y;
            }
            return false;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(4, projectile.Center, 15);
            NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, ModContent.NPCType<MiniHypo>());
            for (int k = 0; k < 25; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<SnowCloudDust>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            if (!Main.expertMode)
                return;
            target.AddBuff(BuffID.Frostburn, 2 * 60 + Main.rand.Next(60));
            target.AddBuff(BuffID.Chilled, 2 * 60 + Main.rand.Next(60));
        }
    }
}
