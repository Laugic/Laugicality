using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
    public class BrittleBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Brittle");
            Description.SetDefault("I feel like I could shatter");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>().Brittle = true;
        }
    }
}
