using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etherial.BossFights
{
    public class SuperShark : ModNPC
    {
        int movementType = 0;
        int movementCounter = 0;
        bool justSpawned = false;
        private Vector2 targetPos;
        float vMag = 0;
        public override void SetDefaults()
        {
            movementCounter = 0;
            LaugicalityVars.etherial.Add(npc.type);
            npc.width = 18;
            npc.height = 18;
            npc.damage = 80;
            npc.defense = 80;
            npc.lifeMax = 4000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath19;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
        }

        public override void AI()
        {
            npc.spriteDirection = (int)npc.ai[1];
            if (!Main.npc[(int)npc.ai[0]].active)
                npc.active = false;
            if (!justSpawned)
            {
                justSpawned = true;
                movementCounter = 45 * (int)npc.ai[1];
                targetPos = Main.player[npc.target].Center;
            }
            Movement();
            npc.rotation = npc.ai[1] * -(float)(Math.PI / 2) + (float)(Math.PI / 2) + (float)Math.Atan2(targetPos.Y - npc.Center.Y, targetPos.X - npc.Center.X);
        }

        private void Movement()
        {
            MovementTypeCheck();
            Move();
            MoveToTarget();
        }

        private void MovementTypeCheck()
        {
            movementCounter++;
            if (movementCounter > 2 * 60 && movementType == 0)
            {
                movementType = 1;
                targetPos.Y += 800;
                movementCounter = 0;
            }
            if (movementCounter > 60 && movementType == 1)
            {
                movementType = 2;
                movementCounter = 0;
            }
            if (movementCounter > 2 * 60 && movementType == 2)
            {
                movementType = 3;
                targetPos.X -= npc.ai[1] * 800;
                movementCounter = 0;
            }
            if (movementCounter > 60 && movementType == 3)
            {
                movementType = 4;
                movementCounter = 0;
            }
            if (movementCounter > 5 * 60 && movementType == 4)
            {
                movementType = 0;
                movementCounter = 0;
            }
        }

        private void Move()
        {
            if (movementType == 0)
            {
                targetPos = Main.player[npc.target].Center;
                targetPos.Y -= 300 + 100 * (int)npc.ai[1];
            }
            if (movementType == 2)
            {
                targetPos = Main.player[npc.target].Center;
                targetPos.X += npc.ai[1] * 300;
            }
            if (movementType == 4)
            {
                if (movementCounter % 60 == 0)
                    targetPos = Main.player[npc.target].Center + (Main.player[npc.target].Center - npc.Center) / 2;
            }
        }

        private void MoveToTarget()
        {
            float dist = Vector2.Distance(targetPos, npc.Center);
            float tVel = dist / 15;
            float vMax = 24;
            if (vMag < vMax && vMag < tVel)
            {
                vMag += .2f;
                vMag = tVel;
            }
            if (vMag > tVel)
            {
                vMag = tVel;
            }
            if (vMag > vMax)
            {
                vMag = vMax;
            }
            if (dist != 0)
            {
                npc.velocity = npc.DirectionTo(targetPos) * vMag;
            }
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
    }
}
