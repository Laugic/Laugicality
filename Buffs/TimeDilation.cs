using Laugicality.NPCs;
using Terraria;

namespace Laugicality.Buffs
{
	public class TimeDilation : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Time Dilation");
			Description.SetDefault("Take a burst of damage when Time is Stopped");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
            canBeCleared = false;
        }
    }
}
