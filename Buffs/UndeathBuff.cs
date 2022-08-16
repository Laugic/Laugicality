using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
    public class UndeathBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Undeath");
            Description.SetDefault("Not quite immortality");
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
