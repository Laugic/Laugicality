using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class EtherialScarf : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("While in the etherial, prevent a hit of lethal damage once every minute. \n20% Damage Reduction");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.2f;
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.etherialScarf = true;
        }
    }
}