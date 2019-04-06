using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class Midnight : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Midnight");
			Description.SetDefault("'Midnight's Moon glows bright on you.'\nUnleash a Midnight Burst when changing Mysticism");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<LaugicalityPlayer>(mod).midnight =true;
        }
        
	}
}
