using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etherial.BossFights
{
    public class SuperSlime : ModNPC
    {
        public bool bitherial = false;
        public bool etherial = true;
        int delay = 0;
        int index = 0;
        Vector2 targetPos;
        public float tVel = 0f;
        public float vel = 0f;
        public float vMax = 10f;
        public float vAccel = .2f;
        public float vMag = 0f;
        float theta = 0;
        int targetType = 0;

        public override void SetDefaults()
        {
            targetType = 0;
            vMag = 0f;
            vMax = 14f;
            tVel = 0f;
            index = 0;
            delay = 0;
            LaugicalityVars.Etherial.Add(npc.type);
            npc.width = 54;
            npc.height = 40;
            npc.damage = 40;
            npc.defense = 80;
            npc.lifeMax = 400;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            Main.npcFrameCount[npc.type] = 2;
            npc.scale *= 1.5f;
        }
        
        public override void AI()
        {
            MovementType(npc);
            MoveToTarget(npc);
            Shoot(npc);
        }
        
        private void MovementType(NPC npc)
        {
            npc.rotation = 0f;
            theta += 3.14f / 30;
            if (Main.npc[(int)npc.ai[0]].active && Main.player[Main.npc[(int)npc.ai[0]].target].statLife > 0)
            {
                if (targetType == 0)
                {
                    float mag = 64;
                    Vector2 rot;
                    rot.X = (float)Math.Cos(theta + 3.14f * npc.ai[1] / 4) * (mag + 32 * npc.ai[1]);
                    rot.Y = (float)Math.Sin(theta + 3.14f * npc.ai[1] / 4) * (mag + 32 * npc.ai[1]);
                    targetPos = Main.npc[(int)npc.ai[0]].Center + rot;
                }
                if (targetType == 1)
                {
                    targetPos = Main.player[Main.npc[(int)npc.ai[0]].target].Center;
                }
            }
            else
                npc.active = false;
        }

        private void MoveToTarget(NPC npc)
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

        private void Shoot(NPC npc)
        {
            delay++;
            if (delay > 480)
            {
                delay = Main.rand.Next(0, 120);
                if (Main.netMode != 1 && targetType == 0)
                {
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("EtherialYeet"), (int)(npc.damage / 4), 3, Main.myPlayer);
                }
                targetType = 1 - targetType;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1.0;
            if (npc.frameCounter > 20.0)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y > frameHeight * 1)
            {
                npc.frame.Y = 0;
            }
        }
        
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialEssence"), 1);
        }
    }
}
