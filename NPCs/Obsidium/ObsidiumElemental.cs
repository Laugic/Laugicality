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
            npc.width = 34;
            npc.height = 32;
            npc.damage = 22;
            npc.defense = 12;
            npc.lifeMax = 80;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            npc.value = 60f;
            npc.knockBackResist = 0.4f;
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            var player = Main.LocalPlayer;
            var mPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);

            if (LaugicalityWorld.obsidiumTiles > 150 && spawnInfo.spawnTileY > WorldGen.rockLayer - 150 && !player.ZoneDungeon)
                return SpawnCondition.Cavern.Chance * 0.75f;
            else return 0f;
        }

        public override void AI()
        {
            npc.rotation = 0.02f;
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
                npc.velocity = (12 * npc.velocity + move) / 11f;
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
            //NPCs.Slybertron.Slybertron.coginatorHits += 1;
            int debuff = BuffID.OnFire;
            if (debuff >= 0)
            {
                target.AddBuff(debuff, 90, true);
            }      //Add Onfire buff to the NPC for 1 second
        }

        public override void NPCLoot()
        {
            if (LaugicalityWorld.obEnf && Main.rand.Next(2) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ObsidiumChunk"));
            }
            else
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 173, Main.rand.Next(4));
            }
        }
    }
}
