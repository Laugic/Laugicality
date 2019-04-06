using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Verdi : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Verdi");
			Description.SetDefault("+10% Max Run Speed");
			Main.buffNoSave[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<LaugicalityPlayer>(mod).Verdi = 2;
        }
        
	}
}
