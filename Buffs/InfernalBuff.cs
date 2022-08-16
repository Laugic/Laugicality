using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
    public class InfernalBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Infernal");
            Description.SetDefault("Burning in your Armor");
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
