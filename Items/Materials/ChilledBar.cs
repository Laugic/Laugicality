using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Materials
{
	public class ChilledBar : ModItem
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
			item.rare = 1;
			item.useAnimation = 1;
			item.useTime = 15;
			item.useStyle = 1;
		}
	}
}