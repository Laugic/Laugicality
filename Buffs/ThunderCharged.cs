using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
    public class ThunderCharged : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Thunder Charged");
            Description.SetDefault("Full of lightning");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {

        }
    }
}
