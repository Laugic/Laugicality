using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class Shroolicopter : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Shroolicopter");
            Description.SetDefault("'Rain Shrooms upon them.'");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("Shroolicopter")] > 0)
			{
				modPlayer.sCopter = true;
			}
			if (!modPlayer.sCopter)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}