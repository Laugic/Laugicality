using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;

namespace Laugicality.NPCs.Obsidium
{
    public class LavaTitan : ModNPC
    {
        bool attacking = false;
        bool attack = false;
        Vector2 targetPos;
        public float tVel = 0f;
        public float vMax = 14f;
        public float vAccel = .2f;
        public float vMag = 0f;
        int attackDelay = 0;
        public override void SetDefaults()
        {
            LaugicalityVars.ENPCs.Add(npc.type);
            attackDelay = 0;
            vMag = 0f;
            vMax = 2f;
            tVel = 0f;
            targetPos = npc.position;
            attack = false;
            attacking = false;
            npc.width = 88;
            npc.height = 88;
            npc.damage = 50;
            npc.defense = 30;
            npc.lifeMax = 4500;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            Main.npcFrameCount[npc.type] = 14;
            npc.value = 20000f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.buffImmune[24] = true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.CountNPCS(mod.NPCType("LavaTitan")) == 0 && LaugicalityWorld.obsidiumTiles > 150 && spawnInfo.spawnTileY > WorldGen.rockLayer && LaugicalityWorld.downedRagnar && Main.hardMode)
                return SpawnCondition.Cavern.Chance * .075f;
            else return 0f;
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 300, true);
        }

        public override void AI()
        {
            //Attack
            if(attack)
            {
                if(Main.netMode != 1)
                {
                    attack = false;
                    for (int i = 0; i < 8; i++)
                    {
                        int N = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("TitanBlast"));
                        Main.npc[N].ai[0] = npc.whoAmI;
                        Main.npc[N].ai[1] = i;
                    }
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 122);
                }
            }
            if(!attacking)
                attackDelay++;
            if(attackDelay > 60 * 4)
            {
                attackDelay = 0;
                attacking = true;
            }

            //Movement
            targetPos = Main.player[npc.target].Center;
            if(!attacking)
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
            else
            {
                npc.velocity.X *= .95f;
                npc.velocity.Y *= .95f;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1;
            if(!attacking)
            {
                if (npc.frameCounter > 30)
                {
                    npc.frame.Y = npc.frame.Y + frameHeight;
                    npc.frameCounter = 0;
                }
                if (npc.frame.Y > frameHeight * 3)
                {
                    npc.frame.Y = 0;
                }
            }
            else
            {
                if (npc.frame.Y < frameHeight * 4)
                {
                    npc.frame.Y = frameHeight * 4;
                }
                if (npc.frameCounter > 4)
                {
                    if (npc.frame.Y > frameHeight * 10 && npc.frame.Y < frameHeight * 12)
                        attack = true;
                    npc.frame.Y = npc.frame.Y + frameHeight;
                    npc.frameCounter = 0;
                }
                if (npc.frame.Y > frameHeight * 13)
                {
                    npc.frame.Y = 0;
                    attacking = false;
                }
            }
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MagmaticCluster"));
        }
    }
}
