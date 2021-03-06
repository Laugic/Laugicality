using Laugicality.Tiles;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Placeable
{
    public class ObsidiumOre : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = Item.sellPrice(silver: 12);
            item.createTile = ModContent.TileType<ObsidiumOreBlock>();
            item.rare = ItemRarityID.Green;
        }
    }
}