using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class TimeExhausted : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Out of Time");
			Description.SetDefault("You cannot use Time Stop for a while");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
            canBeCleared = false;
        }
        

		public override void Update(Player player, ref int buffIndex)
		{
			    player.GetModPlayer<LaugicalityPlayer>(mod).zCool = true;
		}
	}
}
