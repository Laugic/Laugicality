using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    [AutoloadEquip(EquipType.Wings)]
    public class Etheramind : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ascension");
            Tooltip.SetDefault("'Rule from above'");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = 2;
            item.expert = true;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.etherial || modPlayer.etherable)
                player.wingTimeMax = 210;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
    ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.etherial || modPlayer.etherable)
            {
                ascentWhenFalling = 0.85f;
                ascentWhenRising = 0.185f;
                maxCanAscendMultiplier = 2.5f;
                maxAscentMultiplier = 4f;
                constantAscend = 0.15f;
            }
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.etherial || modPlayer.etherable)
            {
                speed = 15f;
                acceleration *= 4f;
            }
        }
    }
}