using Laugicality.NPCs;
using Terraria;

namespace Laugicality.Buffs
{
	public class TimeDilation : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Time Dilation");
			Description.SetDefault("Periodically spawns Time Capsules");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
            canBeCleared = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>().TimeDilation = true;
        }
    }
}
