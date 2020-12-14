using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
    public class SandyBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sandy");
            Description.SetDefault("There's sand in my eyes!");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>().Sandy = true;
        }
    }
}
