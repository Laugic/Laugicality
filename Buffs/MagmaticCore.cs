using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class MagmaticCore : LaugicalityBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Magmatic Core");
            Description.SetDefault("This ball of hardened magma will fight for you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("MagmaticCore")] > 0)
			{
				modPlayer.MoltenCoreSummon = true;
			}
			if (!modPlayer.MoltenCoreSummon)
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