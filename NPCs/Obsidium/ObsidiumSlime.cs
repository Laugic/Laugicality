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
    public class ObsidiumSlime : ModNPC
    {
        public override void SetDefaults()
        {
            //npc.frameWidth = 40;
            //npc.frameHeight = 34;
            npc.width = 40;
            npc.height = 34;
            npc.damage = 42;
            npc.defense = 12;
            npc.lifeMax = 150;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            npc.value = 0f;
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
        public override void AI()
        {
            if (npc.life > 0)
            {
                npc.life = 0;
                NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, 24);
            }
        }
    }
}
