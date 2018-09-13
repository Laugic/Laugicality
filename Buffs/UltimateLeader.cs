using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class UltimateLeader : ModBuff
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
				modPlayer.uBois = true;
			}
			if (!modPlayer.uBois)
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