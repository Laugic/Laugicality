using Terraria;
using Terraria.ID;


namespace Laugicality.Items.Equipables
{
    public class Eruption : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eruption");
            Tooltip.SetDefault("Release an Eruption when changing Mysticism.\n+5% Mystic Burst Damage");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 36;
            item.value = 10000;
            item.rare = ItemRarityID.Blue;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticEruption = true;
            modPlayer.MysticBurstDamage += .05f;
        }
        
    }
}