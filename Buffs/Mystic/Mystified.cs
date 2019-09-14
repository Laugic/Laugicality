using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs.Mystic
{
	public class Mystified : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Mystified");
			Description.SetDefault("Disintegrating!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<LaugicalityPlayer>(mod).Mystified = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<LaugicalGlobalNPCs>(mod).mFied = true;
		}
	}
}
