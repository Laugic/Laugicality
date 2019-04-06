using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class MysticBurstPotion : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Burst Power");
			Description.SetDefault("'Mystical energy swells within you.'\nDecreases Mystic Burst cooldown");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<LaugicalityPlayer>(mod).MysticSwitchCoolRate += 1;
        }
        
	}
}
