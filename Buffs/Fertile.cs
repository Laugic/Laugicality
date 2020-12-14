using Laugicality.NPCs;
using Terraria;

namespace Laugicality.Buffs
{
    public class Fertile : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Fertile");
            Description.SetDefault("Seeds grow within you.");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
            canBeCleared = false;
        }


        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>().Fertile = true;
        }
    }
}
