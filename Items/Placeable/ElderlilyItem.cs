using Terraria.ID;

namespace Laugicality.Items.Placeable
{
    public class ElderlilyItem : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elderlily");
            Tooltip.SetDefault("An ancient bloom");
        }
        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createTile = Terraria.ModLoader.ModContent.TileType<Tiles.Lycoris>();
        }
    }
}