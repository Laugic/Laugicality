using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class Rubrum : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Rubrum");
			Description.SetDefault("+10% Damage");
			Main.buffNoSave[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
        {
            player.thrownDamage += 0.1f;
            player.rangedDamage += 0.1f;
            player.magicDamage += 0.1f;
            player.minionDamage += 0.1f;
            player.meleeDamage += 0.1f;
        }
	}
}
