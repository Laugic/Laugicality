using System;
using Laugicality.NPCs.Etheria;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    public class RagnarHand : ModNPC
    {
        Vector2 targetPos;
        public float tVel = 0f;
        public float vel = 0f;
        public float vMax = 10f;
        public float vAccel = .2f;
        public float vMag = 0f;
        int movementType = 0;
        int counter = -1;
        double theta1 = 0;
        double theta2 = 0;

        public override void SetDefaults()
        {
            targetPos.X = 0;
            targetPos.Y = 0;
            counter = -1;
            movementType = 0;
            vMag = 0f;
            vMax = 18f;
            tVel = 0f;
            LaugicalityVars.eNPCs.Add(npc.type);
            npc.width = 30;
            npc.height = 30;
            npc.damage = 25;
            npc.defense = 10;
            npc.lifeMax = 2400;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
        }

        public override bool CheckActive()
        {
            return false;
        }

        public override void AI()
        {
            if (Main.npc[(int)npc.ai[1]].active)
                GetMovementType();
            else
                npc.active = false;

            RunCounter();
            GetRotation();
        }

        private void GetMovementType()
        {
            switch(movementType)
            {
                case 0:
                    CircleRagnar();
                    break;
                case 1:
                    HoverPlayer();
                    break;
                case 2:
                    CirclePlayer();
                    break;
                default:
                    GrabPlayer();
                    break;
            }
        }

        private void RunCounter()
        {
            if (counter == -1)
                counter = 60 * (int)npc.ai[0];

            counter++;
            theta1 += Math.PI / 60;

            if (movementType == 0 && counter > 10 * 60)
                ResetCounter();
            if (movementType == 1 && counter > 3 * 60)
                ResetCounter();
            if (movementType == 2 && counter > 12 * 60)
                ResetCounter();
            if (movementType == 3 && counter > 4 * 60)
                ResetCounter();
            if (movementType >= 4)
                movementType = 0;
        }

        private void GetRotation()
        {
            if (movementType == 3)
                npc.rotation += .1f;
            else
                npc.rotation = 0;
            npc.spriteDirection = 0;
        }

        private void ResetCounter()
        {
            counter = 0;
            movementType++;
        }

        private void CircleRagnar()
        {
            targetPos = Main.npc[(int)npc.ai[1]].Center;
            targetPos.X += 80 * (float)Math.Cos(Math.PI * npc.ai[0]);
            targetPos.Y += 20 * (float)Math.Sin(theta1 + Math.PI * npc.ai[0]);
            MoveToTargetPosFast();
        }

        private void CirclePlayer()
        {
            targetPos = Main.player[Main.npc[(int)npc.ai[1]].target].Center;
            targetPos.X += (float)Math.Cos(theta1 + Math.PI * npc.ai[0]) * 140;
            targetPos.Y += (float)Math.Sin(theta1 + Math.PI * npc.ai[0]) * 140;
            MoveToTargetPosFast();
        }

        private void HoverPlayer()
        {
            if (counter < 2 * 60)
            {
                targetPos = Main.player[Main.npc[(int)npc.ai[1]].target].Center;
                targetPos.Y -= 240;
            }
            else if (counter >= 2 * 60 && counter < 2 * 60 + 2)
            {
                targetPos = Main.player[Main.npc[(int)npc.ai[1]].target].Center;
                targetPos.Y += 360;
            }
            MoveToTargetPosFast();
        }

        private void GrabPlayer()
        {
            targetPos = Main.player[Main.npc[(int)npc.ai[1]].target].Center;
            MoveToTargetPosSlow();
        }

        private void MoveToTargetPosFast()
        {
            Vector2 newVel = Vector2.Normalize(targetPos - npc.Center);
            newVel *= Math.Min(Vector2.Distance(npc.Center, targetPos) / 4, Math.Min(npc.velocity.Length() + .6f, 12));
            npc.velocity = newVel;
        }

        private void MoveToTargetPosSlow()
        {
            Vector2 newVel = Vector2.Normalize(targetPos - npc.Center);
            newVel *= Math.Min(Vector2.Distance(npc.Center, targetPos) / 4, Math.Min(npc.velocity.Length() + .6f, 6));
            npc.velocity = newVel;
        }
    }
}
