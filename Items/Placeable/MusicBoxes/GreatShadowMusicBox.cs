using Terraria.ModLoader;

namespace Laugicality.Items.Placeable.MusicBoxes
{
    public class GreatShadowMusicBox : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Music Box (Surface Obsidium)");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = ModContent.TileType<Tiles.MusicBoxes.GreatShadowMusicBox>();
            item.accessory = true;
        }
    }
}