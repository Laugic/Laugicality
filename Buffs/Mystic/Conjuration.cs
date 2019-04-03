using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs.Mystic
{
	public class Conjuration : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Conjuration");
            Description.SetDefault("Draw energy from other worlds");
            Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
        }
    }
}
