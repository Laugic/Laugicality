using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class ObsidiumLily : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obsidium Lily");
            Tooltip.SetDefault("Immunity to Lava, Burning, and 'On Fire!'\n+10% Damage and +5 Defense in the Obsidium and Underworld");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>();
            if(player.ZoneUnderworldHeight || modPlayer.zoneObsidium)
            {
                modPlayer.DamageBoost(.1f);
                player.statDefense += 5;
            }
        }
    }
}