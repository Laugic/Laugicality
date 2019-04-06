using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs.Mystic
{
	public class Hermes : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Hermes");
			Description.SetDefault("Be smitten");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}
        

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<LaugicalGlobalNpCs>(mod).hermes = true;
		}
	}
}
