using Laugicality.Projectiles.Pets;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Consumables
{
	public class ObsidiumHeart : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases the strength of Obsidium weapons\nIncreases your Max Potentia by 10\nCan be used 5 times\nGrown on Magma Shards");
        }
        public override void SetDefaults()
        {
            item.width = 28;
			item.height = 28;
            item.maxStack = 99;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Orange;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item4;
            item.consumable = true;
		}
        public override bool UseItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (player.itemAnimation == player.itemAnimationMax - 1 && LaugicalityPlayer.Get(player).ObsidiumHeart < 5)
            {
                item.stack--;
                modPlayer.ObsidiumHeart++;
                modPlayer.LuxMaxPermaBoost += 10;
                modPlayer.VisMaxPermaBoost += 10;
                modPlayer.MundusMaxPermaBoost += 10;
            }
            return base.UseItem(player);
        }
    }
}