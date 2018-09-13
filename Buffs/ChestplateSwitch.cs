using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class ChestplateSwitch : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Unstable Mysticism");
			Description.SetDefault("Your Mysticism is unstable, and you've temporarily lost power");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
            canBeCleared = false;
        }
        

		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<LaugicalityPlayer>(mod).destructionPower -= 1;
            player.GetModPlayer<LaugicalityPlayer>(mod).illusionPower -= 1;
            player.GetModPlayer<LaugicalityPlayer>(mod).conjurationPower -= 1;
        }
	}
}
