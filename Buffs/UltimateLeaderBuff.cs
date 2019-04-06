using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class UltimateLeaderBuff : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Ultimate Leader");
            Description.SetDefault("This nebula swarm will fight for you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("UltimateLeader1")] > 0)
			{
				modPlayer.UltraBoisSummon = true;
			}
			if (!modPlayer.UltraBoisSummon)
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