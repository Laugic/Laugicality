using Terraria.ID;

namespace Laugicality.Items.Materials
{
	public class Gear : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Like a Cog, but better.'");
        }
        public override void SetDefaults()
		{
			item.width = 38;
			item.height = 38;
			item.maxStack = 99;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 1;
			item.useTime = 15;
			item.useStyle = 1;
            item.value = 1000;
		}
        
	}
}