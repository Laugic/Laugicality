using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class MysticPower : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Mystic Power");
			Description.SetDefault("'The energy of the cosmos strengthens you.'\n+10% Mystic Damage");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<LaugicalityPlayer>(mod).MysticDamage += 0.1f;
        }
        
	}
}
