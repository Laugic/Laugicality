using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Albus : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Albus");
			Description.SetDefault("+10% Damage Reduction");
			Main.buffNoSave[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
        {
            player.endurance += 0.10f;
        }
        
	}
}
