using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Spored : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Spored");
			Description.SetDefault("Smokin hot!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<LaugicalGlobalNPCs>(mod).spored = true;
		}
	}
}
