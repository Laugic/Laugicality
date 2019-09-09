using Laugicality.Tiles;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class Barrier : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("An invisible block");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createTile = mod.TileType<BarrierTile>();
        }

        public override void HoldItem(Player player)
        {
            player.GetModPlayer<LaugicalityPlayer>().HoldingBarrier = true;
            base.HoldItem(player);
        }
    }
}