using Laugicality.Projectiles.Summon;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class UltimateLeaderBuff : LaugicalityBuff
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
			LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
			if (player.ownedProjectileCounts[ModContent.ProjectileType<UltimateLeader1>()] > 0)
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