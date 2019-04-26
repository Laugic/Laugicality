using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class DartCopter : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Dart Copter");
			Description.SetDefault("One darty boi is fighting for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("DartCopter")] > 0)
			{
				modPlayer.DartCopterSummon = true;
			}
			if (!modPlayer.DartCopterSummon)
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