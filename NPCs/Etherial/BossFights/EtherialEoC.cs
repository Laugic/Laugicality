using System;
using Laugicality.NPCs.Etheria;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etherial.BossFights
{
    public class EtherialEoC : ModNPC
    {
        int movementType = 0;
        int movementCounter = 0;
        bool justSpawned = false;
        private Vector2 targetPos;
        float vMag = 0;
        int counter = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Eye of Cthulhu");
        }

        public override void SetDefaults()
        {
            movementCounter = 0;
            LaugicalityVars.etherial.Add(npc.type);
            npc.width = 124;
            npc.height = 124;
            npc.damage = 180;
            npc.defense = 50;
            npc.lifeMax = 100000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath19;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 4;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            Main.npcFrameCount[npc.type] = 6;
            npc.boss = true;
        }

        public override void AI()
        {
            if (!justSpawned)
            {
                justSpawned = true;
                movementCounter = 45 * (int)npc.ai[1];
                targetPos = Main.player[npc.target].Center;
            }
            if (npc.life > npc.lifeMax * 2 / 3)
                Shoot();
            else
            {
                Movement();
                npc.rotation = (float)Math.Atan2(targetPos.Y - npc.Center.Y, targetPos.X - npc.Center.X) - 1.57f;
            }
        }

        private void Movement()
        {
            npc.aiStyle = 0;
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

        private void Shoot()
        {
            counter++;
            if(counter >= 4 * 60)
            {
                counter = 0;
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, ModContent.ProjectileType<EtherialYeet>(), (int)(npc.damage / 4), 3, Main.myPlayer);
            }
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1.0;
            if (npc.frameCounter > 24.0)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y > frameHeight * 2 && npc.life > npc.lifeMax * 2 / 3)
            {
                npc.frame.Y = 0;
            }
            else if(npc.frame.Y > frameHeight * 5 && npc.life <= npc.lifeMax * 2 / 3)
            {
                npc.frame.Y = 3 * frameHeight;
            }
        }
    }
}
