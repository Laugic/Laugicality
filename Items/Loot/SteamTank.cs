using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Loot
{
    public class SteamTank : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Steam powered!\nIncreases Mystic damage by 12%\n+20% Overflow\nIncreases movement speed by 50% and jump height by 2\nReduces the cooldown between Mystic Bursts.");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 48;
            item.value = 100;
            item.rare = ItemRarityID.Green;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            player.jumpSpeedBoost += 2f;
            player.moveSpeed += 0.5f;
            modPlayer.MysticDamage += 0.12f;
            modPlayer.MysticSwitchCoolRate += 1;
            modPlayer.GlobalOverflow += .2f;
        }
    }
}