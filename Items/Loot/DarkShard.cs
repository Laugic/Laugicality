using Laugicality.Tiles;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Loot
{
    public class DarkShard : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Shard");
            Tooltip.SetDefault("Grows Obsidium Hearts over time when placed");
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
            item.consumable = true;
            item.createTile = ModContent.TileType<MagmaVeins>();
            item.value = Item.sellPrice(silver: 50);
            item.rare = ItemRarityID.Orange;
        }
    }
}