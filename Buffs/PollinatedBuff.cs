using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
    public class PollinatedBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Pollinated");
            Description.SetDefault("I'm about to sneeze");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>().Pollinated = true;
        }
    }
}
