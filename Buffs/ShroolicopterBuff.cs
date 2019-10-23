using Laugicality.Projectiles.Summon;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class ShroolicopterBuff : LaugicalityBuff
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
			LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
			if (player.ownedProjectileCounts[ModContent.ProjectileType<ShroolicopterProjectile>()] > 0)
			{
				modPlayer.ShroomCopterSummon = true;
			}
			if (!modPlayer.ShroomCopterSummon)
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