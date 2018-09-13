using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class ObsidiumLily : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obsidium Lily");
            Tooltip.SetDefault("Attack stats are increased for a time after being submerged in Lava");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if(player.lavaWet)
                player.AddBuff(mod.BuffType("BurningFragrance"), 60 * 15);
        }
    }
}