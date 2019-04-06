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
    public class SuperMechanicalMinion : ModNPC
    {
        public bool bitherial = false;
        public bool etherial = true;
        int delay = 0;
        int index = 0;
        Vector2 targetPos;
        public float tVel = 0f;
        public float vel = 0f;
        public float vMax = 32f;
        public float vAccel = .2f;
        public float vMag = 0f;
        float theta = 0;
        int targetType = 0;

        public override void SetDefaults()
        {
            targetType = 0;
            vMag = 0f;
            vMax = 32f;
            tVel = 0f;
            index = 0;
            delay = 0;
            LaugicalityVars.Etherial.Add(npc.type);
            npc.width = 54;
            npc.height = 40;
            npc.damage = 40;
            npc.defense = 80;
            npc.lifeMax = 400;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
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
                    float mag = 320;
                    Vector2 rot;
                    rot.X = (float)Math.Cos(theta + 3.14f * npc.ai[1] / 4) * (mag + 32 * npc.ai[1]);
                    rot.Y = (float)Math.Sin(theta + 3.14f * npc.ai[1] / 4) * (mag + 32 * npc.ai[1]);
                    targetPos = Main.npc[(int)npc.ai[0]].Center + rot;
                }
                if (targetType == 1)
                {
                    float mag = 128;
                    Vector2 rot;
                    rot.X = (float)Math.Cos(theta + 3.14f * npc.ai[1] / 4) * (mag + 32 * npc.ai[1]);
                    rot.Y = (float)Math.Sin(theta + 3.14f * npc.ai[1] / 4) * (mag + 32 * npc.ai[1]);
                    targetPos = Main.player[Main.npc[(int)npc.ai[0]].target].Center + rot;
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
        
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialEssence"), 1);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Microsoft.Xna.Framework.Color color9 = Lighting.GetColor((int)((double)npc.position.X + (double)npc.width * 0.5) / 16, (int)(((double)npc.position.Y + (double)npc.height * 0.5) / 16.0));
            float num66 = 0f;
            Vector2 vector11 = new Vector2((float)(Main.npcTexture[npc.type].Width / 2), (float)(Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2));
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (npc.spriteDirection == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            Microsoft.Xna.Framework.Rectangle frame6 = npc.frame;
            Microsoft.Xna.Framework.Color alpha15 = npc.GetAlpha(color9);
            float num212 = 1f - (float)npc.life / (float)npc.lifeMax;
            num212 *= num212;
            alpha15.R = (byte)((float)alpha15.R * num212);
            alpha15.G = (byte)((float)alpha15.G * num212);
            alpha15.B = (byte)((float)alpha15.B * num212);
            alpha15.A = (byte)((float)alpha15.A * num212);
            for (int num213 = 0; num213 < 4; num213++)
            {
                Vector2 position9 = npc.position;
                float num214 = Math.Abs(npc.Center.X - Main.player[Main.myPlayer].Center.X);
                float num215 = Math.Abs(npc.Center.Y - Main.player[Main.myPlayer].Center.Y);
                if (num213 == 0 || num213 == 2)
                {
                    position9.X = Main.player[Main.myPlayer].Center.X + num214;
                }
                else
                {
                    position9.X = Main.player[Main.myPlayer].Center.X - num214;
                }
                position9.X -= (float)(npc.width / 2);
                if (num213 == 0 || num213 == 1)
                {
                    position9.Y = Main.player[Main.myPlayer].Center.Y + num215;
                }
                else
                {
                    position9.Y = Main.player[Main.myPlayer].Center.Y - num215;
                }
                position9.Y -= (float)(npc.height / 2);
                Main.spriteBatch.Draw(Main.npcTexture[npc.type], new Vector2(position9.X - Main.screenPosition.X + (float)(npc.width / 2) - (float)Main.npcTexture[npc.type].Width * npc.scale / 2f + vector11.X * npc.scale, position9.Y - Main.screenPosition.Y + (float)npc.height - (float)Main.npcTexture[npc.type].Height * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + vector11.Y * npc.scale + num66 + npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(frame6), alpha15, npc.rotation, vector11, npc.scale, spriteEffects, 0f);
            }
            Main.spriteBatch.Draw(Main.npcTexture[npc.type], new Vector2(npc.position.X - Main.screenPosition.X + (float)(npc.width / 2) - (float)Main.npcTexture[npc.type].Width * npc.scale / 2f + vector11.X * npc.scale, npc.position.Y - Main.screenPosition.Y + (float)npc.height - (float)Main.npcTexture[npc.type].Height * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + vector11.Y * npc.scale + num66 + npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(frame6), npc.GetAlpha(color9), npc.rotation, vector11, npc.scale, spriteEffects, 0f);
            return false;
        }
    }
}
