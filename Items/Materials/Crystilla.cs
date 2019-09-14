namespace Laugicality.Items.Materials
{
    public class Crystilla : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("An ancient gemstone");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = 0;
        }
    }
}