using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Materials
{
    public class BottledPinkGel : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The Pink Gel has consumed the normal gel.\nRight Click to open.");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.maxStack = 1;
            item.rare = ItemRarityID.Orange;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            //item.UseSound = SoundID.Item9;
            item.consumable = true;
        }

        public override bool CanRightClick()
        {
           return true;
        }
        
        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(ItemID.PinkGel, Main.rand.Next(2, 5));
            player.QuickSpawnItem(ItemID.Bottle, 1);
        }
        
    }
}