using Laugicality.Projectiles.Summon;
using Terraria;
using Terraria.ModLoader;

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
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (player.ownedProjectileCounts[ModContent.ProjectileType<AndesiaProbe>()] > 0)
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
