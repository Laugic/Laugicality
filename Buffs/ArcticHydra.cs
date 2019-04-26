using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Buffs
{
    public class ArcticHydra : LaugicalityBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Arctic Hydra");
            Description.SetDefault("The Hydra Hoard will fight for you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (player.ownedProjectileCounts[mod.ProjectileType("ArcticHydraHead")] > 0)
            {
                modPlayer.ArcticHydraSummon = true;
            }
            if (!modPlayer.ArcticHydraSummon)
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