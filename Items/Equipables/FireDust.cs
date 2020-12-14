using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Equipables
{
    public class FireDust : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fire Dust");
            Tooltip.SetDefault("All attacks inflict 'On Fire!'");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Orange;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.Obsidium = true;
        }
    }
}