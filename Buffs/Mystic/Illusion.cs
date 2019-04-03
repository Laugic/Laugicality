using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs.Mystic
{
	public class Illusion : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Illusion");
            Description.SetDefault("The power of the mind is yours");
            Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}
    }
}
