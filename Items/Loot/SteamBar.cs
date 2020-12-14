using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Loot
{
    public class SteamBar : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = Item.sellPrice(silver: 50);
            item.rare = ItemRarityID.Pink;
        }
    }
}