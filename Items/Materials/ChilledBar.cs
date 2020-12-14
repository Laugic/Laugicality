using Terraria.ID;
using Terraria;

namespace Laugicality.Items.Materials
{
	public class ChilledBar : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Very Cold");
        }
        public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.maxStack = 99;
			item.useAnimation = 1;
			item.useTime = 15;
			item.useStyle = 1;
            item.value = Item.sellPrice(silver: 24);
			item.rare = ItemRarityID.Blue;
        }
	}
}