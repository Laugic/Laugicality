using Laugicality.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class BloodfootBoots : BootItem
    {
        public override void SetStaticDefaults()
        {
            LaugicalityVars.DashBoots.Add(item.type);
            DisplayName.SetDefault("Bloodfoot Boots");
            Tooltip.SetDefault("Allows the wearer to dash");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Blue;
            item.accessory = true;
        }

        public override void SetBootVars()
        {
            DashCooldownMax = 45;
            DashSpeed = 11;

            DustType = ModContent.DustType<Black>();
            TrailLength = 15;
        }
    }
}