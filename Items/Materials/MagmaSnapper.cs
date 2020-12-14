using Terraria.ID;
using Terraria;

namespace Laugicality.Items.Materials
{
    public class MagmaSnapper : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Don't get your hand too close.'");
        }

        public override void SetDefaults()
        {
            item.width = 66;
            item.height = 58;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = Item.sellPrice(silver: 15);
            item.rare = ItemRarityID.Blue;
        }
        
    }
}