using Terraria;
using Terraria.ID;

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
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Orange;
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
            player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[BuffID.OnFire] = true;
        }
    }
}