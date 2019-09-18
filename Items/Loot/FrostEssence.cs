using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Loot
{
    public class FrostEssence : LaugicalityItem
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
            item.rare = ItemRarityID.Green;
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