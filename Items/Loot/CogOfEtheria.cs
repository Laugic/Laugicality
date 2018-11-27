using Terraria;
using Terraria.ModLoader;
using Laugicality.Items;

namespace Laugicality.Items.Loot
{
    public class CogOfEtheria : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cog of Etheria");
            Tooltip.SetDefault("Increases your max number of minions by 4 while in the Etherial");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.etherial || modPlayer.etherable)
                modPlayer.etherCog = true;
        }
    }
}