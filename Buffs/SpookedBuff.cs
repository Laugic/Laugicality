using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class SpookedBuff : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Spooked");
			Description.SetDefault("Many spoops!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}
	}
}
