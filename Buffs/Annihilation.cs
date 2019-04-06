using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Annihilation : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Annihilation");
			Description.SetDefault("You are infused with the rage of an Annihilator.");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
            canBeCleared = false;
        }
        

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<LaugicalityPlayer>(mod).annihilationBoost = true;
		}
	}
}