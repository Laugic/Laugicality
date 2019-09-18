namespace Laugicality.Items.Loot
{
    public class RoyalIce : LaugicalityItem
    {

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'A Queen's Tear'");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = 0;
        }

    }
}