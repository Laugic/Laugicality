using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Equipables
{
    public class Ragnashia : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ragnashia");
            Tooltip.SetDefault("+5% Crit Chance\nSet nearby enemies ablaze");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Orange;
            item.accessory = true;
            item.defense = 5;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<LaugicalityPlayer>().CritBoost(5);
            player.GetModPlayer<LaugicalityPlayer>().Blaze = true;
        }
    }
}