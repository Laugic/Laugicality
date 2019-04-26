using Terraria.ModLoader;

namespace Laugicality.Items.Placeable.MusicBoxes
{
    public class SteamTrainMusicBox : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Music Box (Steam Train)");
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
            item.createTile = mod.TileType<Tiles.MusicBoxes.SteamTrainMusicBox>();
            item.accessory = true;
        }
    }
}