using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Extensions;
using Microsoft.Xna.Framework.Graphics;
using Laugicality.Dusts;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
    public class PoseidonConjuration1 : PrimaryConjurationProjectile
    {
        Vector2 targetPos;
        int counter = 0;
        double theta = 0;
        int movementType = 0;
        int bubbleCounter = 0;

        public override void SetDefaults()
        {
            counter = -1;
            movementType = 0;
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 12 * 60;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 4;
        }

        public override void AI()
        {
            Bubbles();
            CheckActive();
            GetTarget();
            CheckTarget();
            Movement();
            RunCounter();
            MakeDust();
        }

        private void Bubbles()
        {
            bubbleCounter++;
            if(bubbleCounter > 30)
            {
                bubbleCounter = 0;
                if (Main.myPlayer == projectile.owner)
                {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y,
                           projectile.velocity.X - (float)Main.rand.NextDouble() + 2 * (float)Main.rand.NextDouble(), projectile.velocity.Y - (float)Main.rand.NextDouble() + 2 * (float)Main.rand.NextDouble(),
                           ModContent.ProjectileType<PoseidonConjuration2>(), projectile.damage, projectile.knockBack, projectile.owner, Main.rand.Next(4));
                    Main.PlaySound(SoundID.Item86, projectile.position);
                }
            }
        }

        public override void PostAI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 4)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 3)
            {
                projectile.frame = 0;
                return;
            }
        }

        private void MakeDust()
        {

        }

        private void ResetCounter()
        {
            counter = 0;
            movementType++;
            targetPos = projectile.position;
        }

        private void RunCounter()
        {
            if (counter == -1)
                counter = 60 * (int)projectile.ai[0];

            counter++;
            theta += Math.PI / 60;

            if (movementType == 0 && counter > 3 * 60)
                ResetCounter();
            if (movementType == 1 && counter > 4 * 60)
                ResetCounter();
            if (movementType >= 2)
                movementType = 0;
        }

        private void Movement()
        {
            if (projectile.ai[1] != -1)
                GetMovementType();
            else
                CirclePlayer();
        }

        private void GetMovementType()
        {
            switch (movementType)
            {
                case 0:
                    CirclePlayer();
                    break;
                default:
                    GrabNPC();
                    break;
            }
        }
        private void CheckTarget()
        {
            if (projectile.ai[1] != -1)
            {
                if (Main.npc[(int)projectile.ai[1]].life < 1 || !Main.npc[(int)projectile.ai[1]].active)
                    projectile.ai[1] = -1;
            }
        }

        public void CheckActive()
        {
            if (!Main.player[projectile.owner].active || Main.player[projectile.owner].statLife == 0)
                projectile.Kill();
        }

        public void GetTarget()
        {
            float dist = 1400;

            foreach (NPC npc in Main.npc)
            {
                if (npc.damage > 0 && npc.type != NPCID.TargetDummy && !npc.townNPC && !npc.dontTakeDamage && !npc.friendly)
                {
                    if (npc.Distance(projectile.Center) < dist)
                    {
                        dist = npc.Distance(projectile.Center);
                        projectile.ai[1] = npc.whoAmI;
                    }
                    if (npc.Distance(Main.player[projectile.owner].Center) < dist * .67)
                    {
                        dist = npc.Distance(Main.player[projectile.owner].Center);
                        projectile.ai[1] = npc.whoAmI;
                    }
                }
            }
            if (projectile.Distance(Main.player[projectile.owner].Center) > 2000)
                projectile.ai[1] = -1;
        }

        private void CirclePlayer()
        {
            targetPos = Main.player[(int)projectile.owner].Center;
            targetPos.X += 80 * (float)Math.Cos(theta + Math.PI * projectile.ai[0]);
            targetPos.Y += 80 * (float)Math.Sin(theta + Math.PI * projectile.ai[0]);
            MoveToTargetPos(99);
        }

        private void GrabNPC()
        {
            if(projectile.Distance(targetPos) < 10)
            {
                float dashDist = 80;
                targetPos = Main.npc[(int)projectile.ai[1]].Center;
                var shift = targetPos - projectile.position;
                shift.Normalize();
                shift *= dashDist;
                shift.RotatedByRandom(MathHelper.ToRadians(45));
                targetPos += shift;
            }
            MoveToTargetPos(6);
        }

        private void MoveToTargetPos(float max)
        {
            Vector2 newVel = Vector2.Normalize(targetPos - projectile.Center);
            newVel *= Math.Min(Vector2.Distance(projectile.Center, targetPos) / 4, Math.Min(projectile.velocity.Length() + .6f, max));
            projectile.velocity = newVel;
        }
    }
}
