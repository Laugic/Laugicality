using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Rubrum : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Rubrum");
			Description.SetDefault("+10% Damage");
			Main.buffNoSave[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
        {
            player.allDamage += 0.1f;
        }
	}
}
