using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs.Mystic
{
	public class Illusion : LaugicalityBuff
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
