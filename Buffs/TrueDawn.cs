using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class TrueDawn : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("TrueDawn");
			Description.SetDefault("Star energy");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>().trueDawn = true;
        }

    }
}
