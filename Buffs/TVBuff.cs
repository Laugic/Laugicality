using Laugicality.Projectiles.Summon;
using Terraria;

namespace Laugicality.Buffs
{
	public class TVBuff : LaugicalityBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("TV");
			Description.SetDefault("Don't watch- it's just fake news.");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);

			if (player.ownedProjectileCounts[mod.ProjectileType<TV>()] > 0)
				modPlayer.TVSummon = true;

            if (!modPlayer.TVSummon)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
				player.buffTime[buffIndex] = 18000;
		}
	}
}