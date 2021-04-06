using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Extensions;

namespace Laugicality.Projectiles.Special
{
    public class MoltenCoreHand : ModProjectile
    {
        Vector2 targetPos;
        int counter = 0;
        double theta = 0;
        int movementType = 0;

        public override void SetDefaults()
        {
            counter = -1;
            movementType = 0;
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 800;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            CheckActive();
            GetTarget();
            CheckTarget();
            Movement();
            RunCounter();
            GetRotation();
        }

        private void ResetCounter()
        {
            counter = 0;
            movementType++;
        }

        private void GetRotation()
        {
            if (movementType == 3)
                projectile.rotation += .1f;
            else
                projectile.rotation = 0;
            projectile.spriteDirection = 0;
        }

        private void RunCounter()
        {
            if (counter == -1)
                counter = 60 * (int)projectile.ai[0];

            counter++;
            theta += Math.PI / 60;

            if (movementType == 0 && counter > 10 * 60)
                ResetCounter();
            if (movementType == 1 && counter > 3 * 60)
                ResetCounter();
            if (movementType == 2 && counter > 12 * 60)
                ResetCounter();
            if (movementType == 3 && counter > 8 * 60)
                ResetCounter();
            if (movementType >= 4)
                movementType = 0;
        }

        private void Movement()
        {
            if (projectile.ai[1] != -1)
                GetMovementType();
            else
                HoverPlayer();
        }

        private void GetMovementType()
        {
            switch (movementType)
            {
                case 0:
                    HoverPlayer();
                    break;
                case 1:
                    HoverNPC();
                    break;
                case 2:
                    CircleNPC();
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
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get(Main.player[projectile.owner]);
            if (!Main.player[projectile.owner].active || laugicalityPlayer.MoltenCore <= 0)
                projectile.Kill();
            if (Main.player[projectile.owner].statLife <= Main.player[projectile.owner].statLifeMax2 / 2 + 1)
                projectile.timeLeft = 4;
        }

        public void GetTarget()
        {
            float dist = 600;

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
            if (projectile.Distance(Main.player[projectile.owner].Center) > 1000)
                projectile.ai[1] = -1;
        }

        private void HoverPlayer()
        {
            targetPos = Main.player[(int)projectile.owner].Center;
            targetPos.X += 80 * (float)Math.Cos(Math.PI * projectile.ai[0]);
            targetPos.Y += 20 * (float)Math.Sin(theta + Math.PI * projectile.ai[0]);
            MoveToTargetPos(99);
        }

        private void CircleNPC()
        {
            targetPos = Main.npc[(int)projectile.ai[1]].Center;
            targetPos.X += (float)Math.Cos(theta + Math.PI * projectile.ai[0]) * 80;
            targetPos.Y += (float)Math.Sin(theta + Math.PI * projectile.ai[0]) * 80;
            MoveToTargetPos(12);
        }

        private void HoverNPC()
        {
            if (counter < 2 * 60)
            {
                targetPos = Main.npc[(int)projectile.ai[1]].Center;
                targetPos.Y -= 80;
            }
            else if (counter >= 2 * 60 && counter < 2 * 60 + 2)
            {
                targetPos = Main.npc[(int)projectile.ai[1]].Center;
                targetPos.Y += 160;
            }
            MoveToTargetPos(12);
        }

        private void GrabNPC()
        {
            targetPos = Main.npc[(int)projectile.ai[1]].Center;
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
