using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
    public class Refracting : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Refracting");
            Description.SetDefault("Sparkly but deadly");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>().Refracting = true;
        }
    }
}
