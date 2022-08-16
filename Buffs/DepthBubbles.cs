using Terraria;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class DepthBubbles : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Depth Bubbles");
			Description.SetDefault("Bubbles!");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}
    }
}
