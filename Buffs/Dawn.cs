using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Dawn : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Dawn");
			Description.SetDefault("Golden energy");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>().dawn = true;
        }

    }
}
