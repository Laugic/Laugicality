using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class EtherialScarfCooldown : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Fragmented Soul");
			Description.SetDefault("Your Etherial Scarf has to regenerate before it can save you again.");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
            canBeCleared = false;
        }
        

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<LaugicalityPlayer>(mod).EtherialScarfCooldown = true;
		}
	}
}
