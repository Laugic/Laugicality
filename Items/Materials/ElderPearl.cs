using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Materials
{
    public class ElderPearl : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'It's emitting a calming energy.'");
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
            item.value = 0;
            item.rare = ItemRarityID.LightPurple;
        }
        
    }
}