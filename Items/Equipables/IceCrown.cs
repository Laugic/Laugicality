using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class IceCrown : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Crown");
            Tooltip.SetDefault("+20% Melee and Ranged crit\n+50% Snowball damage\n'The authority of the snow'");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.sellPrice(gold: 9);
            item.rare = ItemRarityID.Yellow;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeCrit += 20;
            player.rangedCrit += 20;
            LaugicalityPlayer.Get(player).SnowDamage += .5f;
        }
    }
}