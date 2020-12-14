using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class DuneSharkronTrophy : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dune Sharkron Trophy");
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
            item.rare = ItemRarityID.Blue;
            item.createTile = ModContent.TileType<Tiles.DuneSharkronTrophyTile>();
        }
    }
}