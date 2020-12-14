using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    public class Ragnarune : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ragnarune");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            LaugicalityVars.eNPCs.Add(npc.type);
            npc.aiStyle = -1;
            npc.width = 40;
            npc.height = 40;
            npc.frame.Y = 0;
            npc.damage = 50;
            npc.lifeMax = 1;
            npc.dontTakeDamage = true;
            npc.ai[2] = 0;
            npc.noGravity = true;
        }

        public override void AI()
        {
            if (!Main.npc[(int)npc.ai[0]].active)
                npc.active = false;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frame.Y = (int)npc.ai[2] * frameHeight;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
    }
}