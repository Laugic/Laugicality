using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs.Mystic
{
	public class Destruction : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Destruction");
            Description.SetDefault("Hell is your catalyst");
            Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
        }
    }
}
