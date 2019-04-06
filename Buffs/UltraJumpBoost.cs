using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class UltraJumpBoost : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Ultra Jump Boost");
			Description.SetDefault("'Reach for the stars.'");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.jumpSpeedBoost += 15.0f;
        }
        
	}
}
