using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Connected : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Connected");
			Description.SetDefault("You are connected to the grid!");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}
        

		public override void Update(Player player, ref int buffIndex)
		{
            if(player.GetModPlayer<LaugicalityPlayer>(mod).connected <= 1)
			    player.GetModPlayer<LaugicalityPlayer>(mod).connected = 1;
		}
	}
}
