using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
    public class Incineration : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Incineration");
            Description.SetDefault("Smokin hot!");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>(mod).incineration = true;
        }
    }
}
