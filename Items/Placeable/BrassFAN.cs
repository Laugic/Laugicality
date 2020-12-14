using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class BrassFAN : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brass F.A.N.");
            Tooltip.SetDefault("It's a 'Fast Acceleration Node'\nBoosts you horizontally");
        }

        public override void SetDefaults()
        {
            item.width = 54;
            item.height = 54;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = Item.buyPrice(gold: 1);
            item.rare = ItemRarityID.Orange;
            item.createTile = ModContent.TileType<Tiles.BrassFAN>();
        }

        public override void UpdateInventory(Player player)
        {
            if (player.direction == 1)
                item.createTile = ModContent.TileType<Tiles.BrassFANRight>();
            else
                item.createTile = ModContent.TileType<Tiles.BrassFAN>();
        }
    }
}