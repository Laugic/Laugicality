using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class CongealedFrostCore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Congealed Frost Core");
            Tooltip.SetDefault("+10% Melee and Ranged damage\n+50% Snowball damage\n'Sometimes, an Ice Golem's Heart is extra cold'");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Pink;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage += .1f;
            player.rangedDamage += .1f;
            LaugicalityPlayer.Get(player).SnowDamage += .5f;
        }
    }
}