using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    [AutoloadEquip(EquipType.Wings)]
    public class Etheramind : LaugicalityItem
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
            item.rare = ItemRarityID.Green;
            item.expert = true;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0)
                player.wingTimeMax = 210;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
    ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0)
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
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0)
            {
                speed = 15f;
                acceleration *= 4f;
            }
        }
    }
}