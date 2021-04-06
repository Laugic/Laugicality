using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Loot
{
    public class MoltenCore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+50 Max Life\nSummon Ragnar Hands when below 50% life");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 44;
            item.value = Item.sellPrice(gold:4);
            item.rare = ItemRarityID.Orange;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 50;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MoltenCore = 2;
        }
    }
}