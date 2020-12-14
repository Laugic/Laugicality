using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
    public class DeathMark : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Death Mark");
            Description.SetDefault("Your time is soon.");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>().DeathMarked = true;
        }
    }
}
