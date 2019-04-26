using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Spooked : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Spooked");
			Description.SetDefault("Many spoops!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}
        

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<LaugicalGlobalNPCs>(mod).spooked = true;
		}
	}
}
