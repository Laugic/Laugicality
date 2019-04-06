using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class MagmaticVeins : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Magmatic Veins");
			Description.SetDefault("Greatly increased movement speed");
			Main.debuff[Type] = false;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.moveSpeed += 3f;
            player.maxRunSpeed += 3f;
            player.jumpSpeedBoost += 3f;
        }
        
	}
}
