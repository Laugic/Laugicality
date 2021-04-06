using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Loot
{
    public class SteamTank : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Steam speed!\n+15% Overflow Capacity and Damage");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 48;
            item.value = Item.sellPrice(gold: 6);
            item.rare = ItemRarityID.Lime;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.jumpSpeedBoost += 2f;
            player.moveSpeed += 0.5f;
            modPlayer.GlobalOverflow += .15f;
            modPlayer.OverflowDamage += .15f;
        }
    }
}