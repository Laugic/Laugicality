using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Obsidium
{
    public class ObsidiumElemental : ModNPC
    {
        public override void SetDefaults()
        {
            npc.width = 40;
            npc.height = 40;
            npc.damage = 30;
            npc.defense = 15;
            npc.lifeMax = 80;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            Main.npcFrameCount[npc.type] = 4;
            npc.value = 60f;
            npc.knockBackResist = 0.4f;
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.buffImmune[24] = true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            var player = Main.LocalPlayer;
            var mPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);

            if (LaugicalityWorld.obsidiumTiles > 250  && LaugicalityWorld.downedRagnar)
                return SpawnCondition.Cavern.Chance * 0.65f;
            else return 0f;
        }

        public override void AI()
        {
            if (npc.localAI[0] == 0f)
            {
                AdjustMagnitude(ref npc.velocity);
                npc.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 1400f;
            bool target = false;
            for (int k = 0; k < 8; k++)
            {
                if (Main.player[k].active)
                {
                    Vector2 newMove = Main.player[k].Center - npc.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            
            if (target)
            {
                AdjustMagnitude(ref move);
                npc.velocity = (12 * npc.velocity + move) / 12f;
                AdjustMagnitude(ref npc.velocity);
            }


        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 4f / magnitude;
            }
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            int debuff = BuffID.OnFire;
            if (debuff >= 0)
            {
                target.AddBuff(debuff, 90, true);
            }
        }

        public override void NPCLoot()
        {
            if (LaugicalityWorld.obEnf && Main.rand.Next(2) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ObsidiumChunk"));
            }
            else
            {
                if (Main.rand.Next(4) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 173, Main.rand.Next(4));
                else
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ObsidiumOre"), Main.rand.Next(1, 4));
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
            if (npc.frame.Y > frameHeight * 3)
            {
                npc.frame.Y = 0;
            }

        }
    }
}
