using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class JumpBoost : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Jump Boost");
			Description.SetDefault("'Reach for the sky.'");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.jumpSpeedBoost += 5.0f;
        }
        
	}
}
