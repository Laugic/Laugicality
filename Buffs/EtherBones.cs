using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class EtherBones : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Ether Bones");
			Description.SetDefault("Your bones are infused with the strength of the Etherial.");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
            canBeCleared = false;
        }
        

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<LaugicalityPlayer>(mod).etherBonesBoost = true;
		}
	}
}
