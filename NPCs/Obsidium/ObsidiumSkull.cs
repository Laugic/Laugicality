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
    public class ObsidiumSkull : ModNPC
    {
        public override void SetDefaults()
        {
            //npc.frameWidth = 40;
            //npc.frameHeight = 34;
            npc.width = 40;
            npc.height = 34;
            npc.damage = 35;
            npc.defense = 12;
            npc.lifeMax = 80;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 10;
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
