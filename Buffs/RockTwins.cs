using Terraria;

namespace Laugicality.Buffs
{
	public class RockTwins : LaugicalityBuff
	{
		public override void SetDefaults()
        {
            DisplayName.SetDefault("Rock Twins");
            Description.SetDefault("The rulers of the caverns will protect you!");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (player.ownedProjectileCounts[mod.ProjectileType("AndesiaProbe")] > 0)
            {
                modPlayer.RockTwinsSummon = true;
            }
            if (!modPlayer.RockTwinsSummon)
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
