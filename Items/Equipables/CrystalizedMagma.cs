using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Equipables
{
    public class CrystalizedMagma : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystallized Magma");
            Tooltip.SetDefault("Leave a trail of fire as you run");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.FireTrail = true;
        }
    }
}