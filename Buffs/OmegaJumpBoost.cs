using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class OmegaJumpBoost : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Omega Jump Boost");
			Description.SetDefault("'Reach for the next dimension.'");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.jumpSpeedBoost += 50.0f;
        }
        
	}
}
