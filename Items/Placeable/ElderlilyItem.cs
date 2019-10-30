using Terraria.ID;

namespace Laugicality.Items.Placeable
{
    public class ElderlilyItem : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elderlily");
            Tooltip.SetDefault("Very Cold");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.maxStack = 99;
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 1;
            item.useTime = 15;
            item.useStyle = 1;
        }
    }
}