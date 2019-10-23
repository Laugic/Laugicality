using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Frostbite : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Frostbite");
			Description.SetDefault("The cold bites back!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			LaugicalityPlayer.Get(player).frostbite = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<LaugicalGlobalNPCs>().frostbite = true;
		}
	}
}
