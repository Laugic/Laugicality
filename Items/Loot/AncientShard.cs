using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Loot
{
    public class AncientShard : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Shard");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 26;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = Item.sellPrice(silver: 25);
            item.rare = ItemRarityID.Blue;
        }
    }
}