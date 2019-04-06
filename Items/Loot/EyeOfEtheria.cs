using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class EyeOfEtheria : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of Etheria");
            Tooltip.SetDefault("Allows you to see all creatures, no matter which dimension you are in.");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = 5;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.EtherVision = true;
        }
        
    }
}