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
    public class SuperHornet : ModNPC
    {
        public bool bitherial = false;
        public bool etherial = true;
        int delay = 0;
        int index = 0;
        Vector2 targetPos;
        public float tVel = 0f;
        public float vel = 0f;
        public float vMax = 4f;
        public float vAccel = .2f;
        public float vMag = 0f;
        float theta = 0;
        int targetType = 0;
        int counter = 0;
        int cooldown = 0;

        public override void SetDefaults()
        {
            counter = 0;
            cooldown = 0;
            targetType = 0;
            vMag = 0f;
            vMax = 14f;
            tVel = 0f;
            index = 0;
            delay = 0;
            LaugicalityVars.Etherial.Add(npc.type);
            npc.width = 18;
            npc.height = 18;
            npc.damage = 40;
            npc.defense = 80;
            npc.lifeMax = 4000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void AI()
        {
            Movement(npc);
            Attack(npc);
        }

        private void Movement(NPC npc)
        {
            delay++;
            if ((delay > 8 * 60 || Main.rand.Next(8 * 60) == 0) && counter == 0)
            {
                delay = Main.rand.Next(0, 120);
                cooldown = 2 * 60;
                MirrorTeleport(npc, false);
            }
            npc.rotation = 0;
            if (cooldown > 0)
                cooldown--;
            if (cooldown > 1 * 60 + 30)
            {
                npc.velocity.X = 0;
                npc.velocity.Y = 0;
            }
            else
            {
                targetPos = Main.player[npc.target].Center;
                MoveToTarget(npc);
            }
            if (Main.player[npc.target].position.X > npc.position.X)
                npc.direction = 1;
            else
                npc.direction = 0;
        }

        private void Attack(NPC npc)
        {
            counter++;
            if (counter > 4 * 60)
            {
                counter = 0;
                if (Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("EtherialStinger"), (int)(npc.damage * .7), 3, Main.myPlayer);
            }
        }

        public override void NPCLoot()
        {
            if (Main.rand.Next(6) == 0) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialEssence"), 1);
        }

        private void MirrorTeleport(NPC npc, bool burst)
        {
            if (burst && Main.player[npc.target].statLife > 1)
            {
                for (int i = 0; i < 8; i++)
                {

                    if (Main.netMode != 1)
                    {
                        int N = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("EtherialSpiralShot"));
                        Main.npc[N].ai[0] = npc.whoAmI;
                        Main.npc[N].ai[1] = i;
                    }
                }
            }
            npc.position.X = Main.player[npc.target].position.X - (npc.position.X - Main.player[npc.target].position.X);
            npc.position.Y = Main.player[npc.target].position.Y - (npc.position.Y - Main.player[npc.target].position.Y);
            npc.velocity.X = -npc.velocity.X;
            npc.velocity.Y = -npc.velocity.Y;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1.0;
            if (npc.frameCounter > 4.0)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y > frameHeight)
            {
                npc.frame.Y = 0;
            }
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
    }
}
