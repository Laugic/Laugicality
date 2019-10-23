using Terraria;

namespace Laugicality.Buffs
{
	public class MysticBurstPotion : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Burst Power");
			Description.SetDefault("'Mystical energy swells within you.'\nDecreases Mystic Burst cooldown");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            LaugicalityPlayer.Get(player).MysticSwitchCoolRate += 1;
        }
        
	}
}
