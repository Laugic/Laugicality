using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
    public class JudgementBuff : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Judgement");
            Description.SetDefault("Bring down weight upon you");
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
