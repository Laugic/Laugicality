using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class FrostEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Attacks inflict 'Frostburn'\n+25% Snowball Damage");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.Frost = true;
            modPlayer.SnowDamage += .25f;
        }
    }
}