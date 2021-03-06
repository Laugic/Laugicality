﻿using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
    public class Slushie : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Slushie");
            Description.SetDefault("Squish");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>().Slushie = true;
        }
    }
}
