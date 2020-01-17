using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Ameldera
{
    public class Fluvium : ModNPC
    {
        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.BlueSlime);
            npc.width = 32;
            npc.height = 32;
            npc.damage = 20;
            npc.defense = 6;
            npc.lifeMax = 120;
            npc.value = 60f;
            npc.lavaImmune = true;
            Main.npcFrameCount[npc.type] = 2;
        }

    }
}
