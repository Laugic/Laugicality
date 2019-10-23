using Laugicality.Projectiles.Summon;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
	public class SandySharkBuff : LaugicalityBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Sandy Shark");
            Description.SetDefault("It looks a bit pouty");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
			if (player.ownedProjectileCounts[ModContent.ProjectileType<SandySharkProjectile>()] > 0)
			{
				modPlayer.SandSharkSummon = true;
			}
			if (!modPlayer.SandSharkSummon)
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