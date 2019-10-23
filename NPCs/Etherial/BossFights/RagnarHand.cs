using System;
using Laugicality.NPCs.Etheria;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etherial.BossFights
{
    public class RagnarHand : ModNPC
    {
        public bool bitherial = false;
        public bool etherial = true;
        Vector2 targetPos;
        public float tVel = 0f;
        public float vel = 0f;
        public float vMax = 10f;
        public float vAccel = .2f;
        public float vMag = 0f;
        int movementType = 0;
        int counter = -1;

        public override void SetDefaults()
        {
            targetPos.X = 0;
            targetPos.Y = 0;
            counter = -1;
            movementType = 0;
            vMag = 0f;
            vMax = 18f;
            tVel = 0f;
            LaugicalityVars.etherial.Add(npc.type);
            npc.width = 36;
            npc.height = 36;
            npc.damage = 40;
            npc.defense = 999;
            npc.lifeMax = 32000;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            Main.npcFrameCount[npc.type] = 3;
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
            if (movementType == 0)
                CircleRagnar();
            if (movementType == 1)
                HoverPlayer();
            if (movementType == 2)
                CirclePlayer();
            if (movementType == 3)
                GrabPlayer();
            MoveToTargetPos();
        }

        private void RunCounter()
        {
            if(counter == -1)
                counter = 60 * (int)npc.ai[0];

            counter++;

            if(movementType == 0 && counter > 8 * 60)
                ResetCounter();
            if (movementType == 1 && counter > 3 * 60)
                ResetCounter();
            if (movementType == 2 && counter > 8 * 60)
                ResetCounter();
            if (movementType == 3 && counter > 5 * 60)
                ResetCounter();
            if (movementType == 4)
                movementType = 0;
        }

        private void GetRotation()
        {
            if (movementType == 3)
                npc.rotation += .1f;
            else
                npc.rotation = 0;
        }

        private void ResetCounter()
        {
            counter = 0;
            if (Main.npc[(int)npc.ai[1]].life > Main.npc[(int)npc.ai[1]].lifeMax * .25)
                movementType++;
            else
                movementType = Main.rand.Next(4);
        }

        private void CircleRagnar()
        {
            float theta = Main.npc[(int)npc.ai[1]].GetGlobalNPC<EtherialGlobalNPC>().armTheta + (float)Math.PI / 2 * npc.ai[0];
            targetPos = Main.npc[(int)npc.ai[1]].Center;
            targetPos.X += (float)Math.Cos(theta) * Main.npc[(int)npc.ai[1]].GetGlobalNPC<EtherialGlobalNPC>().armDist;
            targetPos.Y += (float)Math.Sin(theta) * Main.npc[(int)npc.ai[1]].GetGlobalNPC<EtherialGlobalNPC>().armDist;
        }

        private void CirclePlayer()
        {
            float theta = Main.npc[(int)npc.ai[1]].GetGlobalNPC<EtherialGlobalNPC>().armTheta + (float)Math.PI / 2 * npc.ai[0];
            targetPos = Main.player[Main.npc[(int)npc.ai[1]].target].Center;
            targetPos.X += (float)Math.Cos(theta) * Main.npc[(int)npc.ai[1]].GetGlobalNPC<EtherialGlobalNPC>().armDist;
            targetPos.Y += (float)Math.Sin(theta) * Main.npc[(int)npc.ai[1]].GetGlobalNPC<EtherialGlobalNPC>().armDist;
        }

        private void HoverPlayer()
        {
            if(counter < 2 * 60)
            {
                targetPos = Main.player[Main.npc[(int)npc.ai[1]].target].Center;
                targetPos.Y -= 240;
            }
            else if(counter >= 2 * 60 && counter < 2 * 60 + 2)
            {
                targetPos = Main.player[Main.npc[(int)npc.ai[1]].target].Center;
                targetPos.Y += 360;
            }
        }

        private void GrabPlayer()
        {
            targetPos = Main.player[Main.npc[(int)npc.ai[1]].target].Center;
        }

        private void MoveToTargetPos()
        {
            float dist = Vector2.Distance(targetPos, npc.Center);
            tVel = dist / 15;
            if (vMag < vMax && vMag < tVel)
            {
                vMag += vAccel;
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

        private void MirrorTeleport(NPC npc, bool burst)
        {
            Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
            if (burst && Main.player[npc.target].statLife > 1)
            {
                for (int i = 0; i < 8; i++)
                {
                    int N = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<EtherialSpiralShot>());
                    Main.npc[N].ai[0] = npc.whoAmI;
                    Main.npc[N].ai[1] = i;
                }
            }
            npc.position.X = Main.player[npc.target].position.X - (npc.position.X - Main.player[npc.target].position.X);
            npc.position.Y = Main.player[npc.target].position.Y - (npc.position.Y - Main.player[npc.target].position.Y);
            npc.velocity.X = -npc.velocity.X;
            npc.velocity.Y = -npc.velocity.Y;
        }

        public override void FindFrame(int frameHeight)
        {
            if (movementType == 3)
                npc.frame.Y = 0;
            else if (movementType == 1 && counter >= 2 * 60)
                npc.frame.Y = frameHeight;
            else
                npc.frame.Y = frameHeight * 2;
        }
    }
}
